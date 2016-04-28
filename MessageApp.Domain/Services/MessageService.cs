using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageApp.Domain.DAL.Entities;
using MessageApp.Domain.Repositories;

namespace MessageApp.Domain.Services
{
    public class MessageService : IMessageService
    {
        private IMessageRepository _messageRepository;
        public MessageService()
            :this(new MessageRepository())
        {
            //Empty
        }

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetMessages()
        {
            return _messageRepository.GetAllMessages();
        } 

        

    }
}
