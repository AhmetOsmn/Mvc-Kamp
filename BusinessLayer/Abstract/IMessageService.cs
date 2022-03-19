using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessageListInbox(string mail);
        List<Message> GetMessageListSendbox(string mail);
        void AddMessage(Message message);
        Message GetMessageByID(int id);
        void DeleteMessage(Message message);
        void UpdateMessage(Message message);
    }
}
