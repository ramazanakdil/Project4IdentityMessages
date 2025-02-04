﻿using Project4IdentityMessages_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4IdentityMessages_BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> TGetMessagesByReceiver(string receiverMail);
        public Message TMessageDetails(int id);
        List<Message> TGetMessagesBySender(string senderMail);
        public Message TMessageDetailsSender(int id);
    }
}
