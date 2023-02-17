using AutoMapper;
using Data.Nikom.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nikom.Models;
using Nikom.Services;

namespace Nikom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;
        public AccountController(
            UserManager<AppUser> userManager,
            IJwtTokenService jwtTokenService,
            SignInManager<AppUser> signInManager,
            IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromForm] RegisterViewModel model)
        {
            var user = _mapper.Map<AppUser>(model);
            return Ok();
        }
    }
}
