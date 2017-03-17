using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Repositories;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MemberController : Controller
    {
        private IMemberRepository memberRepo;
        // GET: /<controller>/

        public MemberController(IMemberRepository repo)
        {
            memberRepo = repo;
        }

        [Route("Members")]
        public ViewResult Members()
        {
            return View(memberRepo.GetAllMember().ToList());
        }

    }
}
