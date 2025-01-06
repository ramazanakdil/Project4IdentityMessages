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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(IdentityMailContext context) : base(context)
        {
        }
    }
}
