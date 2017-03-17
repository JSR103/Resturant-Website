using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private ApplicationDbContext context;
        private Message message;

        public MemberRepository(ApplicationDbContext ctx)//going to take a instants of context
        {
            context = ctx;
        }
        public List<Member> GetMemberBylastname()
        {
            var members = new List<Member>();
            members.Add(new Member() { FirstName = "Megan", LastName = "Kale", Joined = new DateTime(2006, 8, 22) });
            members.Add(new Member() { FirstName = "Jame", LastName = "Abe", Joined = new DateTime(2002, 10, 2) });
            members.Add(new Member() { FirstName = "Rena", LastName = "Frampton", Joined = new DateTime(2013, 3, 12) });
            return members;

        }

        public IEnumerable<Member> GetAllMember()
        {
            return context.Members.ToList();
        }


    }
}
