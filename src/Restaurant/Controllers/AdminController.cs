using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Repositories;
using Restaurant.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private IMessageRepository repository;

        public AdminController(IMessageRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.GetAllMessages());

        public ViewResult Edit(int MessageID)
        {
            ViewBag.MessageID = MessageID;
            return View(repository.GetAllMessages().FirstOrDefault(m => m.MessageID == MessageID));
        }

        [HttpPost]
        public IActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                repository.Update(message);
                TempData["message"] = $"{message.MessageID} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(message);
            }
        }

        public IActionResult Create() => RedirectToAction("MessageForm", "Message");

        [HttpPost]
        public IActionResult Delete(int messageID)
        {
            Message deletedMessage = repository.DeleteMessage(messageID);
            if (deletedMessage != null)
            {
                TempData["message"] = $"{deletedMessage.MessageID} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
