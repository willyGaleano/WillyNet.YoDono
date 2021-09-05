using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Domain.Entities;

namespace WillyNet.YoDono.Infraestructure.Persistence.Contexts
{
    public class DataUserDefault
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                new AppUser
                 {
                    FirstName = "Williams",
                    LastName = "Galeano",
                    UserName = "Willy23",
                    Email = "willyrhcp96@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                },
                new AppUser
                {
                    FirstName = "Bryan",
                    LastName = "Cordova",
                    UserName = "Bryan23",
                    Email = "bryan@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                },
                new AppUser
                {
                    FirstName = "Yamile",
                    LastName = "Silva",
                    UserName = "Yamile23",
                    Email = "yamile@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                },
                new AppUser
                {
                    FirstName = "Brandon",
                    LastName = "Salazar",
                    UserName = "Brandon23",
                    Email = "brandon@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                },
                new AppUser
                {
                    FirstName = "Jainy",
                    LastName = "Sanchez",
                    UserName = "Jainy23",
                    Email = "jainy@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                }
            };
                
                foreach(var user in users)
                    await userManager.CreateAsync(user, "Holamundo123*");
            }

            if (!roleManager.Roles.Any())
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole
                {
                    Name = "ADMIN"
                },
                    new IdentityRole
                {
                    Name = "BASIC"
                },
                };
                
                foreach(var role in roles)
                    await roleManager.CreateAsync(role);
            }

        }
    }
}
