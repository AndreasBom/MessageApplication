using System;
using System.Collections.Generic;
using MessageApp.Domain.DAL.Entities;

namespace MessageApp.Domain.Repositories
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<Message> GetAllMessages();
        Message GetMessageById(int messageId);
        void InserMessage(Message message);
        void DeleteMessage(int messageId);
        void Save();
    }
}
