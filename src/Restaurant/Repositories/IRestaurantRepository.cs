using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Repositories
{
    public interface IRestaurantRepository
    {
        IEnumerable<Menu1> GetAllMenu1();

        int Update(Menu1 menu1);

        Menu1 DeleteMessage(int menu1ID);
        IEnumerable<Menu1> Foods { get; }
    }
}
