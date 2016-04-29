using System;
using System.Collections.Generic;
using System.Linq;
using MessageApp.Domain.DAL.Entities;


namespace MessageApp.Domain.Repositories
{
    public abstract class MessageRepositoryBase : IMessageRepository
    {
        protected abstract IQueryable<Message> QueryMessages();
        public IEnumerable<Message> GetAllMessages()
        {
            return QueryMessages().OrderBy(m=>m.DateTime).ToList();
        }
        public Message GetMessageById(int messageId)
        {
            return QueryMessages().SingleOrDefault(m => m.Id == messageId);
        }
        public abstract void InserMessage(Message message);
        public abstract void DeleteMessage(int messageId);
        public abstract void Save();

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
