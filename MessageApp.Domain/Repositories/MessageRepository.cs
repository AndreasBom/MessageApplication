using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageApp.Domain.DAL;
using MessageApp.Domain.DAL.Entities;
using MessageApp.Domain.Repositories;

namespace MessageApp.Domain.Repositories
{
    /// <summary>
    /// Repository class that handles Messages in database
    /// </summary>
    public class MessageRepository : MessageRepositoryBase
    {
        private readonly MessageDbContext _context;

        public MessageRepository()
            : this(new MessageDbContext())
        {

        }

        public MessageRepository(MessageDbContext dbContext)
        {
            _context = dbContext;
        }

        protected override IQueryable<Message> QueryMessages()
        {
            return _context.Messages.AsQueryable();
        }
        public override void InserMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public override void DeleteMessage(int messageId)
        {
            var message = _context.Messages.Find(messageId);
            _context.Messages.Remove(message);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
