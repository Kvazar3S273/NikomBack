using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nikom.Models;

namespace Nikom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromForm] RegisterViewModel model)
        {
            return Ok();
        }
    }
}
