using AutoMapper;
using Data.Nikom.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nikom.Constants;
using Nikom.Models;
using Nikom.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Nikom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtConfig _jwtTokenService;
        private readonly RoleManager<AppRole> _roleManager;
        public AccountController(
            UserManager<AppUser> userManager,
            IJwtConfig jwtTokenService,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("register")]
        //public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        //{
        //    var user = _mapper.Map<AppUser>(model);

        //    if (model.Photo != null)
        //    {
        //        string randomFileName = Path.GetRandomFileName() +
        //            Path.GetExtension(model.Photo.FileName);
        //        string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
        //        string fileName = Path.Combine(dirPath, randomFileName);
        //        using (var file = System.IO.File.Create(fileName))
        //        {
        //            model.Photo.CopyTo(file);
        //        }
        //        user.Photo = randomFileName;
        //    }

        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }
        //    result = await _userManager.AddToRoleAsync(user, Roles.User);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }
        //    return Ok(new
        //    {
        //        token = _jwtTokenService.CreateToken(user)
        //    });
        //    return Ok();
        //}
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterViewModel model)
        {
            try
            {
                var role = new AppRole
                {
                    Name = Roles.User
                };
                var result1 = _roleManager.CreateAsync(role).Result;
                string fileName = String.Empty;
                var user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName
                };

                if (model.Photo != null)
                {
                    string randomFileName = Path.GetRandomFileName() +
                        Path.GetExtension(model.Photo.FileName);
                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
                    fileName = Path.Combine(dirPath, randomFileName);
                    using (var file = System.IO.File.Create(fileName))
                    {
                        model.Photo.CopyTo(file);
                    }
                    user.Photo = randomFileName;
                }

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(fileName))
                        System.IO.File.Delete(fileName);
                    return BadRequest(new { message = result.Errors });

                }

                await _userManager.AddToRoleAsync(user, role.Name);

                await _signInManager.SignInAsync(user, isPersistent: false);

                return Ok(new
                {
                    token = _jwtTokenService.CreateToken(user)
                });
            }
            catch
            {
                return BadRequest(new { message = "Error database" });
            }
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Incorrect data!" });
            }

            return Ok(new
            {
                token = _jwtTokenService.CreateToken(user)
            });
        }

    }
}
