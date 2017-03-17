using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    public class NewsController : Controller
    {
        // GET: /<controller>/

        [Route("News")]
        public IActionResult News()
        {
            var news = new News(); //var is a shortcut, it will firgure out the  type
            news.Title = "Trump Takes the House";
            news.ReleaseDate = new DateTime(2017,1,20).ToLocalTime();
            news.Writers = new List<string>() { "Tedy Mosby", "Carl Tia", "Liliana Rem", "Taylor Swift" };
            ViewBag.Kaelin = DateTime.Now;
            return View(news);
        }


        [Route("News/Archive")]
        public IActionResult Archive()
        {
            var newsold = new News(); //var is a shortcut, it will firgure out the  type
            newsold.Title = "The Roits prepare";
            newsold.ReleaseDate = new DateTime(2017, 1, 20).ToLocalTime();
            newsold.Writers = new List<string>() { "Tedy Mosby", "Kaelin Rin", "Rin Sasuke", "Taylor Swift" };
            return View(newsold);
        }
    }
}
