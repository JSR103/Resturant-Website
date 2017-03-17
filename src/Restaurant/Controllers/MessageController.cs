using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Repositories;
using Restaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    [Authorize(Roles = "Member, Administrator")]
    public class MessageController : Controller
    {
        private IMessageRepository messageRepo;
       

        public MessageController(IMessageRepository repo)
        {
            messageRepo = repo;

        }
        // GET: /<controller>/
        [Route("Messages")]
        public ViewResult Messages()
        {
            return View(messageRepo.GetAllMessages().ToList());
        }

        [Route("MBS")]
        public ViewResult MessageBySubject(string subject)
        {
            // return View(messageRepo.GetMessageBySubject("C#"));
            return View(messageRepo.GetAllMessages().Where(m => m.Subject == subject).ToList());
        }
        [Route("MBM")]
        public ViewResult MessageByMember(Member member)
        {
            return View(messageRepo.GetMessageByMember(member));
        }
        [HttpGet]
        public ViewResult MakeNewMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeNewMessage(/*int messageid*/ string subject, string category, string body)
        {
  
            if (ModelState.IsValid)
            {
                var message = new Message();
                var member = new Member { FirstName = "Ron", LastName = "Sawnson", Email = "Park.N.Rec@gmail.com" };
               // message.MessageID = messageid;
                message.Subject = subject;
             
                message.Body = body;
                message.Date = DateTime.Now;
                message.From = member;
                messageRepo.Update(message);
                return RedirectToAction("Messages", "Message");
            }
            else
            {
                return View();
            }
        }  
    }
}
