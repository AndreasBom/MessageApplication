using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessageApp.Domain.DAL.Entities;
using MessageApp.Domain.Repositories;

namespace MessageApp.MVC.ViewModel
{
    public class MessageViewModel
    {
        private readonly MessageRepository _messageRepository = new MessageRepository();
        public IEnumerable<Message> Message => _messageRepository.GetAllMessages();
    }
}