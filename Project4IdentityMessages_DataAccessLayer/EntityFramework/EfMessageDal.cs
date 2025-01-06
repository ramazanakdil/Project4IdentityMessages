using Microsoft.EntityFrameworkCore;
using Project4IdentityMessages_DataAccessLayer.Abstract;
using Project4IdentityMessages_DataAccessLayer.Context;
using Project4IdentityMessages_DataAccessLayer.Repositories;
using Project4IdentityMessages_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4IdentityMessages_DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(IdentityMailContext context) : base(context)
        {
        }

        public List<Message> GetMessagesByReceiver(string receiverMail)
        {
            using var context = new IdentityMailContext();
            return context.Messages
                .Include(y=>y.Category)
                .Where(x => x.ReceiverMail == receiverMail)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();
        }
    }
}
