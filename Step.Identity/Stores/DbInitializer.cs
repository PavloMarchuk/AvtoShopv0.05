using Microsoft.AspNetCore.Identity;
using Step.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step.Identity.Stores
{
    public static class DbInitializer
    {
        public static void Initialize(StepIdentityContext context,
                         UserManager<AppUser> usermgr,
                         RoleManager<AppRole> rolemgr)//UserContext is EF context
        {

            context.Database.EnsureCreated();//if db is not exist ,it will create database .but ,do nothing .
            if (context.Users.Any() || context.Roles.Any())
            {
                return;   // DB has been seeded
            }

           
            if (!rolemgr.RoleExistsAsync("AppModerator").Result)
            {
                var role2 = new AppRole { Name = "AppModerator" };
                IdentityResult roleResult = rolemgr.CreateAsync(role2).Result;
            }

            if (!rolemgr.RoleExistsAsync("AppUser").Result)
            {
                var role2 = new AppRole { Name = "AppUser" };
                IdentityResult roleResult = rolemgr.CreateAsync(role2).Result;
            }


            if (usermgr.FindByNameAsync("masha@gmail.com").Result == null)
            {
                var user1 = new AppUser
                {
                    FirstName = "Masha",
                    LastName = "Shtoda",
                    UserName = "masha@gmail.com",
                    Birthday = new DateTime(2000, 12, 31),

                    Email = "masha@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                };

                IdentityResult result = usermgr.CreateAsync(user1, "Qwerty123_").Result;

                if (result.Succeeded)
                {
                    usermgr.AddToRoleAsync(user1,
                                        "AppModerator").Wait();
                  
                }
            }

        }
    }
}
