using Data.Nikom;
using Data.Nikom.Entities.Identity;
using Data.Nikom.Entities.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Nikom.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Nikom.Seeder
{
    public static class PartSeeder
    {
        public static void CategorySeedData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Categories.Any())
            {
                var categories = new List<Category>()
                {
                        new Category
                        {
                             Name="Транзистори"
                        },
                        new Category
                        {
                             Name="Діоди"
                        },
                        new Category
                        {
                             Name="Конденсатори"
                        },
                        new Category
                        {
                             Name="Резистори"
                        },
                        new Category
                        {
                             Name="Мікросхеми"
                        }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
        }
        public static void SubCategorySeedData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.SubCategories.Any())
            {
                var subCategories = new List<SubCategory>()
                {
                        new SubCategory
                        {
                             Name="NPN"
                        },
                        new SubCategory
                        {
                             Name="PNP"
                        },
                        new SubCategory
                        {
                             Name="Випрямлячі"
                        },
                        new SubCategory
                        {
                             Name="Танталові"
                        },
                        new SubCategory
                        {
                             Name="Мікроконтроллери"
                        }
                };
                context.SubCategories.AddRange(subCategories);
                context.SaveChanges();
            }
        }
        public static void LocationSeedData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Locations.Any())
            {
                var locations = new List<Location>()
                {
                        new Location
                        {
                             Name="Склад",
                             Box="110"
                        },
                        new Location
                        {
                             Name="Магазин",
                             Box="218"
                        },
                        new Location
                        {
                             Name="Ангар",
                             Box="705"
                        }
                        
                };
                context.Locations.AddRange(locations);
                context.SaveChanges();
            }
        }
        public static void PartSeedData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Parts.Any())
            {
                var parts = new List<Part>()
                {
                        new Part
                        {
                             Name="KT315A",
                             Photo="picture_transistor",
                             Price=2,
                             CategoryId=1,
                             SubCategoryId=1,
                             LocationId=2
                        },
                        new Part
                        {
                             Name="KT361B",
                             Photo="picture_transistor",
                             Price=2,
                             CategoryId=1,
                             SubCategoryId=2,
                             LocationId=2
                        },
                        new Part
                        {
                             Name="1N4007",
                             Photo="picture_diode",
                             Price=1,
                             CategoryId=2,
                             SubCategoryId=3,
                             LocationId=1
                        },
                        new Part
                        {
                             Name="PIC16F628A",
                             Photo="picture_MC",
                             Price=97,
                             CategoryId=5,
                             SubCategoryId=5,
                             LocationId=1
                        },
                        

                };
                context.Parts.AddRange(parts);
                context.SaveChanges();
            }
        }
    }
}
