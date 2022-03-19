using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddMessage(Message message)
        {
            _messageDal.Create(message);
        }

        public void DeleteMessage(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetMessageByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetMessageListInbox(string mail)
        {
            return _messageDal.Read(x => x.ReceiverMail == mail);
        }

        public List<Message> GetMessageListSendbox(string mail)
        {
            return _messageDal.Read(x => x.SenderMail == mail);
        }

        public void UpdateMessage(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
