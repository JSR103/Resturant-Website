using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Repositories
{
    public class Menu1Repository : IRestaurantRepository
    {
        private ApplicationDbContext context;

        public Menu1Repository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Menu1> GetAllMenu1()
        {
            return context.Menu1s.ToList();
        }

        public int Update(Menu1 menu1)
        {
            if (menu1.Menu1ID == 0)
                context.Menu1s.Add(menu1);
            else
                context.Menu1s.Update(menu1);

            return context.SaveChanges();
        }
        public Menu1 DeleteMessage(int menuID)
        {
            Menu1 dbEntry = context.Menu1s.FirstOrDefault(m => m.Menu1ID == menuID);
            if (dbEntry != null)
            {
                context.Menu1s.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<Menu1> Foods => context.Menu1s;
    }
}
