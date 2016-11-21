using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ColaNet.Core.AppService;
using ColaNet.Models.Entitys;
namespace ColaNet.Web.Application
{
    public interface IUserAppService : IAppService
    {
         User Add(User entity);

         User Get(long Id);
    }
}