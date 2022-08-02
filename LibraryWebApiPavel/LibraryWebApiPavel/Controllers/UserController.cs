using LibraryWebApiPavel.Dtos;
using LibraryWebApiPavel.Models;
using LibraryWebApiPavel.Repository;
using LibraryWebApiPavel.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace LibraryWebApiPavel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository<User> _userRepository;

        public AuthController(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserDto request)
        {
            var response = await _userRepository.Register(
                new User { Username = request.Username }, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserDto request)
        {
            var response = await _userRepository.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
