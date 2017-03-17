using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Models;
using Restaurant.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{

    public class NewMessageController : Controller
    {
        private IMessageRepository NMRepo;

        public NewMessageController(IMessageRepository repo)
        {
            NMRepo = repo;
        }
        // GET: /<controller>/
        [HttpGet]
        public ViewResult Forum(string subject, int id)
        {
            var Nmes = new NMViewModel();
            Nmes.Subject = subject;
            Nmes.MessageID = id;
            Nmes.newmes = new NewMessage();
            return View(Nmes);
        }

        [HttpPost]
        public IActionResult Forum(NMViewModel nmv)
        {
            //if (nmv.newmes.Body.IndexOf(" ", StringComparison.Ordinal) < 1)
            //{
            //    string prop = "newmes.Body";
            //    ModelState.AddModelError(prop, "Please enter at least two words");
            //}

            //if (ModelState.IsValid)
            //{
            //    Message message = (from m in NMRepo.GetAllMessages()
            //                       where m.MessageID == nmv.MessageID
            //                       select m).FirstOrDefault<Message>();
            //    message.NewMessage.Add(nmv.nm);
            //    NMRepo.Update(message);

            //    return RedirectToAction("Messages", "Message");
            Message message = (from m in NMRepo.GetAllMessages()
                               where m.MessageID == nmv.MessageID
                               select m).FirstOrDefault<Message>();

            message.NewMessage.Add(nmv.newmes);
            NMRepo.Update(message);

            return RedirectToAction("Messages", "Message");
        
        }
    }
}
