using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Starcatcher.Api.Application.DTO;
using Starcatcher.Api.Application.Services;
using Starcatcher.Api.Domain.Entities;
using Starcatcher.Domain.Entities;

namespace Starcatcher.Api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly TokenGenerator _tokenGenerator = new();
        private readonly PasswordHasher<User> _passwordHasher = new();


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetUserById(id));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Add([FromBody] CreationUserDto user)
        {
            return Created("", _userRepository.Add(user));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserDto user)
        {
            return Ok(_userRepository.Update(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return NoContent();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDTORequest credentials)
        {
            User? existingUser = _userRepository.GetUserByEmail(credentials.Email);

            if (existingUser == null) return Unauthorized(new { message = "Incorrect e-mail or password" });

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(existingUser, existingUser.Password, credentials.Password);

            if (passwordVerificationResult != PasswordVerificationResult.Success)
                return Unauthorized(new { message = "Incorrect e-mail or password" });

            var token = _tokenGenerator.Generate(existingUser);
            return Ok(new { token });
        }
    }
}