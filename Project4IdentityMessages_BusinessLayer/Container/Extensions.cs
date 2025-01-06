using Microsoft.Extensions.DependencyInjection;
using Project4IdentityMessages_BusinessLayer.Abstract;
using Project4IdentityMessages_BusinessLayer.Concrete;
using Project4IdentityMessages_DataAccessLayer.Abstract;
using Project4IdentityMessages_DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4IdentityMessages_BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();
        }
    }
}
