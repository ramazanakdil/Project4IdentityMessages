using Project4IdentityMessages_BusinessLayer.Abstract;
using Project4IdentityMessages_DataAccessLayer.Abstract;
using Project4IdentityMessages_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4IdentityMessages_BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public List<Message> TGetAll()
        {
            return _messageDal.GetAll();
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetMessagesByReceiver(string receiverMail)
        {
            return _messageDal.GetMessagesByReceiver(receiverMail);
        }

        public List<Message> TGetMessagesBySender(string senderMail)
        {
            return _messageDal.GetMessagesBySender(senderMail);
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public Message TMessageDetails(int id)
        {
            return _messageDal.MessageDetails(id);
        }

        public Message TMessageDetailsSender(int id)
        {
            return _messageDal.MessageDetailsSender(id);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
