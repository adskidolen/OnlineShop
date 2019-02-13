namespace KeepHome.Web.Middlewares
{
    using KeepHome.Common;
    using KeepHome.Data;
    using KeepHome.Models;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, KeepHomeContext dbContext,
           UserManager<KeepHomeUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.Roles.Any())
            {
                await this.SeedRoles(userManager, roleManager);
            }
            //if (!dbContext.Products.Any())
            //{
            //    this.SeedLegla(dbContext);
            //    this.SeedMatraci(dbContext);
            //    this.SeedShkafoveZaMivka(dbContext);
            //}

            await this.next(context);
        }

        //private void SeedShkafoveZaMivka(KeepHomeContext dbContext)
        //{
        //    for (int i = 1; i <= 50; i++)
        //    {
        //        var product = new Product
        //        {
        //            ChildCategoryId = 1,
        //            Name = $"Шкаф за мивка {i}",
        //            Description = $"Описание на Шкаф за мивка {i}",
        //            ImageUrl = "https://www.ikea.bg/images/250x250/19873361/godmorgon-odensvik-shkaf-s-mivka-i-2-chekmedzheta-byal-glants-0.jpg?v=2",
        //            Price = (decimal)(i * i) + (decimal)0.99,
        //            Quantity = new Random().Next(0, 50)
        //        };

        //        dbContext.Products.Add(product);
        //        dbContext.SaveChanges();
        //    }
        //}

        //private void SeedMatraci(KeepHomeContext dbContext)
        //{
        //    for (int i = 1; i <= 50; i++)
        //    {
        //        var product = new Product
        //        {
        //            ChildCategoryId = 1,
        //            Name = $"Матрак {i}",
        //            Description = $"Описание на Матрак {i}",
        //            ImageUrl = "https://www.ikea.bg/images/250x250/79125573/espevar-osnova-za-matrak-frensko-leglo-s-pruzhinno-yadro-0.jpg?v=0",
        //            Price = (decimal)(i * i) + (decimal)0.99,
        //            Quantity = new Random().Next(0, 50)
        //        };

        //        dbContext.Products.Add(product);
        //        dbContext.SaveChanges();
        //    }
        //}

        //private void SeedLegla(KeepHomeContext dbContext)
        //{
        //    for (int i = 1; i <= 50; i++)
        //    {
        //        var product = new Product
        //        {
        //            ChildCategoryId = 1,
        //            Name = $"Легло {i}",
        //            Description = $"Описание на Легло {i}",
        //            ImageUrl = "https://www.ikea.bg/images/250x250/69156305/gjora-leglo-breza-0.jpg?v=0",
        //            Price = (decimal)(i * i) + (decimal)0.99,
        //            Quantity = new Random().Next(0, 50)
        //        };

        //        dbContext.Products.Add(product);
        //        dbContext.SaveChanges();
        //    }
        //}

        private async Task SeedRoles(UserManager<KeepHomeUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminRoleExists = await roleManager.RoleExistsAsync(GlobalConstants.AdminRoleName);
            var userRoleExist = await roleManager.RoleExistsAsync(GlobalConstants.UserRoleName);

            if (!adminRoleExists || !userRoleExist)
            {
                var adminRoleResult = await roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdminRoleName));
                var userRoleResult = await roleManager.CreateAsync(new IdentityRole(GlobalConstants.UserRoleName));
            }
        }
    }
}