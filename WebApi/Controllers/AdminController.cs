using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        //Get: api/Admin
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Admin>))]
        public IActionResult GetAdmin()
        {
            var admin = _adminRepository.GetAdmin();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            return Ok(admin);
        }

        // POST: api/Admin
        [HttpPost("register")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAdmin(Admin admin)
        {
            if (admin == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_adminRepository.Create(admin))
            {
                ModelState.AddModelError("", "Something went wrong while creating admin");
                return StatusCode(500, ModelState);
            }

            return Created("/api/admin/", admin);

        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Login(Admin adminLogin)
        {
            if (adminLogin == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var admin = _adminRepository.GetAdmin();

            if (adminLogin.UserName != admin.UserName)
                return BadRequest(new { message = "invalid credentials" });

            if (!BCrypt.Net.BCrypt.Verify(adminLogin.Password, admin.Password))
                return BadRequest(new { message = "invalid credentials" });

            var token = GenerateToken(admin.UserName);

            return Ok(new { token, Message = "success" });

        }

        [Authorize] 
        [HttpGet("validate-token")]
        public IActionResult ValidateToken()
        {
            return Ok(new { message = "Token is valid" });
        }

        static private string GenerateToken(string username)
            {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("secret key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(1), // Set expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        //[HttpPost("logout")]
        //[ProducesResponseType(200)]
        //public IActionResult Logout()
        //{            
        //    Response.Cookies.Delete("jwt");

        //    return Ok(new
        //    {
        //        message = "success"
        //    });
        //}

        [HttpPut()]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAdmin(Admin adminUpdate)
        {
            if (adminUpdate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_adminRepository.Update(adminUpdate))
            {
                ModelState.AddModelError("", "something went wrong while updating admin");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
