using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Repositories
{
    public interface IMemberRepository
    {

        /* List<Member> GetMemberByMessage(Message mes);
         Member GetMemberBylastname();*/
        IEnumerable<Member> GetAllMember();

        List<Member> GetMemberBylastname();

       
    }
}
