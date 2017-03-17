using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDbContext context;
        private Member member;

        public MessageRepository(ApplicationDbContext ctx)//going to take a instants of context
        {
            context = ctx;
        }


        public IQueryable<Message> GetAllMessages()
        {
            return context.Messages.Include(m => m.From).Include(m => m.NewMessage);
        }

        public List<Message> GetMessageBySubject(string subject)
        {
            return context.Messages.Where(m => m.Subject == subject).Include(m => m.From).ToList();
        }
        public List<Message> GetMessageByMember(Member member)
        {
            return context.Messages.Where(m => m.From.MemberID == member.MemberID).ToList();
        }

        public int Update(Message message)
        {
            if (message.MessageID == 0)
                context.Messages.Add(message);
            else
                context.Messages.Update(message);

            return context.SaveChanges();
        }
        public Message DeleteMessage(int messageID)
        {
            Message dbEntry = context.Messages
                .FirstOrDefault(m => m.MessageID == messageID);
            if (dbEntry != null)
            {
                context.Messages.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public IEnumerable<Message> Messages => new List<Message>//It does not use this it uses the database
        {                                                        //I know it looks at it but if you run ut message
                                                                //Subject Answer  look at the body it starts with Yeah
                                                                //But in my database it is Ywah 
            new Message { Subject = "C#",
                    Body = "Does anybody know how to do this?",
                    Date = new DateTime(2006, 8, 22),From=member},
            new Message {  Subject = "Answer",
                    Body = "Yeah I can, What you need help with?",
                    From=member,
                    Date = new DateTime(2006, 10, 23)},
            new Message { Subject = "C#",
                    Body = "I finshed mine any one need help?",
                    From=member,
                    Date = new DateTime(2006, 9, 23) },
            new Message {  Subject = "Slack",
                    Body = "New to Slack",
                    From=member,
                    Date = new DateTime(2006, 9, 23)}
        };
    }
}
