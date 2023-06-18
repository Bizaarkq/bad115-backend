using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bad115_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace bad115_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly Bad115Context _context;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, Bad115Context context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(User usuario)
        {
            var user = await _context.Users
            .Where(u => u.Email == usuario.Email)
            .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            if (BCrypt.Net.BCrypt.Verify(usuario.Password, user.Password) == false)
            {
                return BadRequest("Contraseña incorrecta");
            }

            var roles = await _context.UsersRoles
            .Include(ur => ur.Rol)
            .Where(ur => ur.UserId == user.IdUser)
            .Select(ur => ur.Rol.Name)
            .ToListAsync();

            string jwt = CreateToken(user, roles);

            return Ok(new {
                jwt = jwt,
                user = new {
                    id = user.IdUser,
                    name = user.Name,
                    email = user.Email
                },
                roles = roles
            });
        }

        private string CreateToken(User user, List<string> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, string.Join(",", roles))
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("jwt:key").Value!
            ));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}