using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Repositories;
using Restaurant.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantRepository restrepo;

        public RestaurantController(IRestaurantRepository repo)
        {
            restrepo = repo;
        }

        // GET: /<controller>/

        [Route("TastyThaiFood")]
        public ViewResult Menu1()
        {
            return View(restrepo.GetAllMenu1().ToList());
        }

       

        [Route("TastyThaiFood/Edit")]
        [Authorize(Roles = "Administrator")]
        public ViewResult Edit(int Menu1ID)
        {
            ViewBag.Menu1ID = Menu1ID;
            return View(restrepo.GetAllMenu1().FirstOrDefault(m => m.Menu1ID == Menu1ID));
        }

        [Route("TastyThaiFood/Index")]
        [Authorize(Roles = "Administrator")]
        public ViewResult Index() => View(restrepo.GetAllMenu1());

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Menu1 menu1)
        {
            if (ModelState.IsValid)
            {
                restrepo.Update(menu1);
                TempData["message"] = $"{menu1.Menu1ID} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(menu1);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int menu1ID)
        {
            Menu1 deletedfood = restrepo.DeleteMessage(menu1ID);
            if (deletedfood != null)
            {
                TempData["message"] = $"{deletedfood.Menu1ID} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
