using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebApi.DTO;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/auth/user")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(LoginDto user)
        {
            if(await _authService.Register(user))
            {
                return Ok("Success");
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto user)
        {
            if (!ModelState.IsValid)
            {               
                return BadRequest(ModelState);
            }
            if(await _authService.Login(user))
            {
                //Token Generation
                var tokenString = _authService.GenerateTokenString(user);
                return Ok(new Response()
                {
                    Token = tokenString,
                    Message = "Logged in Successfully"
                }); 
            }            
            return BadRequest("Something went wrong");
        }
    }
    
}
