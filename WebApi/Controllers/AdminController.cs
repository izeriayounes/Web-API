using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Helper;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly JwtService _jwtService;

        public AdminController(IAdminRepository adminRepository, JwtService jwtService)
        {
            _adminRepository = adminRepository;
            _jwtService = jwtService;
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

            return Ok(new
            {
                Message = "success"
            });
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

        //[HttpGet("admin")]
        //public IActionResult Admin()
        //{
        //    try
        //    {
        //        var jwt = Request.Cookies["jwt"];
        //        var token = _jwtService.Verify(jwt);
        //        var admin = _adminRepository.GetAdmin();

        //        return Ok(admin);
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        return Unauthorized();
        //    }
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
