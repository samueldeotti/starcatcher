using Starcatcher.Api.Application.DTO;
using Starcatcher.Domain.Entities;

namespace Starcatcher.Api.Domain.Entities;
public interface IUserRepository
{

    IEnumerable<UserDto> GetUsers();
    User? GetUserByEmail(string email);
    UserDto? GetUserById(int id);
    UserDto Add(CreationUserDto user);
    UserDto Update(UpdateUserDto user);
    void Delete(int id);

    // LoginDTOResponse Login(LoginDTORequest crendentials);
    
}