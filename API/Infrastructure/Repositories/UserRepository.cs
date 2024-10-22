using Microsoft.AspNetCore.Identity;
using Starcatcher.Api.Application.DTO;
using Starcatcher.Api.Application.Services;
using Starcatcher.Api.Domain.Entities;
using Starcatcher.Domain.Entities;
using Starcatcher.Infrastructure.Data;

namespace Starcatcher.Api.Infrastructure.Repositories
{
  public class UserRepository(DatabaseContext context) : IUserRepository
  {
    protected readonly DatabaseContext _context = context;
    private readonly PasswordHasher<User> _passwordHasher = new();
    // private readonly TokenGenerator _tokenGenerator;

    public IEnumerable<UserDto> GetUsers()
    {
      return _context.Users.Select(UserDto.FromEntity).ToList();
    }
    public UserDto? GetUserById(int id)
    {
      return UserDto.FromEntity(_context.Users
          .FirstOrDefault(u => u.UserId == id) ?? throw new Exception("User not found"));
    }

    public UserDto Add(CreationUserDto user)
    {
      User? existingUser = GetUserByEmail(user.Email);

      if (existingUser != null) throw new Exception("Email already in use");

      var newUser = user.ToEntity();

      newUser.Password = _passwordHasher.HashPassword(newUser, user.Password);

      _context.Users.Add(newUser); 

      _context.Wallets.Add(new Wallet
      {
        User = newUser, 
        UserId = newUser.UserId, 
        Balance = 0,
        CreatedAt = DateTime.Now
      });

      _context.SaveChanges();

      return UserDto.FromEntity(newUser); 
    }

    public UserDto Update(UpdateUserDto user)
    {
      User? existingUser = _context.Users
        .FirstOrDefault(u => u.UserId == user.UserId)
        ?? throw new Exception("User not found");

      if (existingUser.Email != user.Email)
      {
        User? existingUserByEmail = GetUserByEmail(user.Email);
        if (existingUserByEmail != null) throw new Exception("Email already in use");
      }

      existingUser.Name = user.Name;
      existingUser.Email = user.Email;
      existingUser.Password = _passwordHasher.HashPassword(existingUser, user.Password);
      existingUser.UpdatedAt = DateTime.Now;
      _context.SaveChanges();
      return UserDto.FromEntity(existingUser);
    }

    public void Delete(int id)
    {
      User? user = _context.Users.FirstOrDefault(user => user.UserId == id) ?? throw new Exception("User not found");
      Wallet? wallet = _context.Wallets.FirstOrDefault(wallet => wallet.UserId == id) ?? throw new Exception("Wallet not found");

      user.DeletedAt = DateTime.Now;
      wallet.DeletedAt = DateTime.Now;

      _context.Users.Update(user);
      _context.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
      return _context.Users
          .FirstOrDefault(u => u.Email == email);
    }

    // public UserDto Login(LoginDTORequest crendentials)
    // {
    //   User? existingUser = GetUserByEmail(crendentials.Email!);

    //   return UserDto.FromEntity(existingUser ?? throw new Exception("User not found"));
    // }
  }
}