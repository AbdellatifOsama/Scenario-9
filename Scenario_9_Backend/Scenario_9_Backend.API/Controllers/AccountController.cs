using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scenario_9_Backend.API.Dtos;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.BLL.Services;
using Scenario_9_Backend.DAL.Entities;
using System.Net;

namespace Scenario_9_Backend.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized();
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized();
            var userDto = new
            {
                message = "success",
                data = new UserDto()
                {
                    Email = loginDto.Email,
                    DisplayName = $"{user.FirstName + " " + user.LastName}",
                    Token = await tokenService.CreateToken(user, userManager)
                }
            };
            return Ok(userDto);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if ((await CheckEmailExistsAsync(registerDto.Email)))
                return new BadRequestObjectResult(new[] { "Email Address already is in Use !!" });
            var user = mapper.Map<ApplicationUser>(registerDto);
            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest();
            var userDto = new UserDto()
            {
                Email = registerDto.Email,
                DisplayName = $"{user.FirstName + " " + user.LastName}",
                Token = await tokenService.CreateToken(user, userManager)
            };
            return Ok(userDto);
        }
        [HttpGet("emailexists")]
        public async Task<bool> CheckEmailExistsAsync([FromQuery] string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is not null)
                return true;
            return false;
        }
    }
}
