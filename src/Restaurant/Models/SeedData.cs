using Restaurant.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            //string firstName = "Bilbo";
            //string lastName = "Baggins";
            //string username = firstName + lastName;
            //string email = "BilboB@theshire.org";
            //string password = "friend";
            //string role = "Reviewers";

            //UserManager<Member> userManager = app.ApplicationServices.GetRequiredService<UserManager<Member>>();
            //RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            if (!context.Messages.Any() /*|| !context.Menu1s.Any() || !context.Menu2s.Any()*/)
            {
                //Member user = await userManager.FindByNameAsync(username);
                //if (user == null)
                //{
                //    user = new Member { FirstName = firstName, LastName = lastName, UserName = username, Email = email };
                //    IdentityResult result = await userManager.CreateAsync(user, password);
                //    if (await roleManager.FindByNameAsync(role) == null)
                //    {
                //        await roleManager.CreateAsync(new IdentityRole(role));
                //        if (result.Succeeded)
                //        {
                //            await userManager.AddToRoleAsync(user, role);
                //        }
                //    }
                //}


                //////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////
                Member member = new Member
                {
                    FirstName = "Joel",
                    LastName = "Silva",
                    Email = "stars.wars@gmail.com"

                };

                context.Members.Add(member);

                Message message = new Message
                {
                    Subject = "C#",
                    Body = "Does anybody know how to do this?",
                    From = member,
                    Date = new DateTime(2006, 8, 22),

                };
                NewMessage newmes = new NewMessage
                {
                    Body = "Yeah I know, whats is the deal?",
                    Subject = "Answer"

                };
                //message.Members.Add(member);
                message.NewMessage.Add(newmes);
                context.Add(message);
                ///////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////
                member = new Member { FirstName = "Devon", LastName = "Lake", Email = "Guild.Of.Wars@gmail.com" };
                context.Members.Add(member);
                message = new Message
                {
                    Subject = "Answer",
                    Body = "Ywah I can, What you need help with?",
                    From = member,
                    Date = new DateTime(2006, 10, 23),

                };
                //message.Members.Add(member);
                context.Add(message);
                ////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////
                member = new Member { FirstName = "Megan", LastName = "Moir", Email = "War.Hammer@gmail.com" };
                context.Members.Add(member);
                message = new Message
                {
                    Subject = "C#",
                    Body = "I finshed mine any one need help?",
                    From = member,
                    Date = new DateTime(2006, 9, 23),


                };
                //message.Members.Add(member);
                context.Add(message);
                ////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////
                member = new Member { FirstName = "Kaelin", LastName = "Kane", Email = "Mass.Effect@gmail.com" };
                context.Members.Add(member);
                message = new Message
                {
                    Subject = "Slack",
                    Body = "New to Slack",
                    From = member,
                    Date = new DateTime(2006, 9, 23),

                };
                // message.Members.Add(new Member { FirstName = "Kaelin", LastName = "Kane",MemberID=4 });
                //message.Members.Add(member);
                context.Add(message);



                Menu1 food = new Menu1
                {
                    NameOfRest1 = "Tasty Thai Food",
                    Name1 = "Pot Stickers",
                    Description1 = "Chicken and vegetable pot stickers served with dipping sauce.",
                    Stars1 = 4,
                    Type1 = "Appetizers",
                    Ingredients1 = 5,
                    Price1 = 5.35m,
                    Location = "Gatway Mall"

                };
                //context.Menu1s.Add(food);
                context.Add(food);

                food = new Menu1
                {
                    NameOfRest1 = "Tasty Thai Food",
                    Name1 = "Calamari",
                    Description1 = "Deep-fried calamari served with a side of Thai chilies hot sauce.",
                    Stars1 = 4,
                    Type1 = "Appetizers",
                    Ingredients1 = 3,
                    Price1 = 6.35m,
                    Location = "Gatway Mall"

                };
                //context.Menu1s.Add(food);
                context.Add(food);
                food = new Menu1
                {
                    NameOfRest1 = "Tasty Thai Food",
                    Name1 = "Chicken Tempura",
                    Description1 = "Marinated chicken breast in Thai seasonings and dipped in our tempura batter and deep-fried. Served with our homemade plum sauce.",
                    Stars1 = 4,
                    Type1 = "Appetizers",
                    Ingredients1 = 5,
                    Price1 = 8.35m,
                    Location = "Gatway Mall"
                };
                //context.Menu1s.Add(food);
                context.Add(food);
                food = new Menu1
                {
                    NameOfRest1 = "Tasty Thai Food",
                    Name1 = "Spicy Fresh Basil",
                    Description1 = "Stir fried grounded chicken or pork with onions, red bell, fresh basil, and green beans.Served with a side of jasmin rice.",
                    Stars1 = 4,
                    Type1 = "Entee",
                    Ingredients1 = 5,
                    Price1 = 13.50m,
                    Location = "Gatway Mall"
                };
                //context.Menu1s.Add(food);
                context.Add(food);


                context.SaveChanges();
            }
        }
    }
}
