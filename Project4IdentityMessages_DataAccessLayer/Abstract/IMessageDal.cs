using Project4IdentityMessages_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4IdentityMessages_DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        List<Message> GetMessagesByReceiver(string receiverMail);
        public Message  MessageDetails(int id);
        List<Message> GetMessagesBySender(string senderMail);

        public Message MessageDetailsSender(int id);
    }
}
