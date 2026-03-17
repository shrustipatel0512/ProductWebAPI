using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductWebApi.Data;
using ProductWebApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ProdutWebApiDbContex _context;
        private readonly IConfiguration _config;

        public AuthController(ProdutWebApiDbContex context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register(User request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPost("login")]
        public IActionResult Login(User request)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return Unauthorized("Invalid credentials");
            }

            var token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.UserName
                })
                .FirstOrDefault();

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }
        public class UserDto
        {
            public int Id { get; set; }
            public string Username { get; set; }
        }
    }
}

