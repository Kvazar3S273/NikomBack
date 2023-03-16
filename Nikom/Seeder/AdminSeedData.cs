using Data.Nikom.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Nikom.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace Nikom.Seeder
{
    public static class AdminSeedData
    {
        public static async Task SeedData(this IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any())
            {
                var role = new AppRole
                {
                    Name = Roles.Admin
                };
                var result1 = roleManager.CreateAsync(role).Result;

                var user = new AppUser
                {
                    Email = "nikom-admin@ukr.net",
                    UserName = "nikom-admin@ukr.net",
                    FirstName = "Володимир",
                    SecondName = "Українець",
                    Photo = "avatarka"
                };
                var res = await userManager.CreateAsync(user, "w3hevN");
                res = await userManager.AddToRoleAsync(user, Roles.Admin);
            }

        }
    }
}
