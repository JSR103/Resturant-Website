using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Models;
using Restaurant.Repositories;

namespace Restaurant.Repositories
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetAllMessages();

        List<Message> GetMessageBySubject(string subject);

        List<Message> GetMessageByMember(Member member);

        IEnumerable<Message> Messages { get; }

        int Update(Message message);

        Message DeleteMessage(int messageID);

    }
}
