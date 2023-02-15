using Microsoft.AspNetCore.Http;

namespace Nikom.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public IFormFile Photo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
