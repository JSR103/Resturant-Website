using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Repositories;
using Restaurant.Models.ViewModels;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
      

        // GET: /<controller>/
        public IActionResult Index()
        {
            var auth = new RegisterViewModel { Authenticated = false };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                auth.FirstName = HttpContext.User.Identity.Name;

                auth.Authenticated = true;
            }
                ViewBag.CurrentDate = DateTime.Now;
            return View(auth);
           
        }

        [Route("Home/About")]
        public IActionResult About()
        {
            return View();
        }
        [Route("Home/About/Contact")]
        public IActionResult Contact()//TO DO
        {
            return View("Contact");
        }
        [Route("Home/History")]
        public IActionResult History()//TO DO
        {
            return View();
        }
    }
}
