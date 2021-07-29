using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Entities;
using ShopApi.Model;
using ShopApi.Service;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var result = await _userService.Authentication(model);
            
            if(result == null)
            {
                return Unauthorized();
            }
            
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            await _userService.Registration(request);

            var result = await _userService.Authentication(new LoginRequest
            {
                Username = request.Username,
                Password = request.Password
            });
            
            return Ok(result);
        }
    }
}