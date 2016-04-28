using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageApp.Domain.DAL.Entities;

namespace MessageApp.Domain.Services
{
    public interface IMessageService
    {
        IEnumerable<Message> GetMessages();
    }
}
