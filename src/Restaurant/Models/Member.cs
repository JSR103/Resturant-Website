using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Restaurant.Models
{
    public class Member : IdentityUser
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Joined { get; set; }

        //  public List<Member> Members { get; set; }
        public override bool Equals(object mem)
        {
            var other = mem as Member;
            if (other == null)
                return false;
            return this.FirstName == other.FirstName &&
                   this.LastName == other.LastName &&
                   this.Email == other.Email;
        }
    }
}
