using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Models;


namespace Restaurant.Repositories
{
    public static class RestaurantIdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string memberUser = "Member";
        private const string adminPassword = "Admin123.";
        private const string password = "Member123.";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices.GetRequiredService<AppIdentityDbContext>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            UserManager<Member> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<Member>>();

            if (!context.Roles.Any())
            {
                IdentityRole admin = new IdentityRole()
                {
                    Name = "Administrator",
                    NormalizedName = "Administrator"
                };

                IdentityRole member = new IdentityRole()
                {
                    Name = "Member",
                    NormalizedName = "Member"
                };
                var adminrolecreate = await roleManager.CreateAsync(admin);
                var memberrolecreate = await roleManager.CreateAsync(member);
            }

            if (!context.Users.Any())
            {
                Member admin = await userManager.FindByIdAsync(adminUser);
                if (admin == null)
                {
                    admin = new Member()
                    {
                        FirstName = "Admin",
                        LastName = "Member",
                        UserName = "Admin",
                        Email = "testadmin@test.com"
                    };

                    var admincreate = await userManager.CreateAsync(admin, adminPassword);
                    var adminrole = await userManager.AddToRoleAsync(admin, "Administrator");
                }

                Member member = await userManager.FindByIdAsync(memberUser);
                if (member == null)
                {
                    member = new Member()
                    {
                        FirstName = "Normal",
                        LastName = "Member",
                        UserName = "Member",
                        Email = "testmember@test.com"
                    };

                    var membercreate = await userManager.CreateAsync(member, password);
                    var memberrole = await userManager.AddToRoleAsync(member, "Member");

                    if (memberrole.Succeeded)
                    {
                        SeedData.EnsurePopulated(app);
                    }
                }
            }
        }
    }
}
