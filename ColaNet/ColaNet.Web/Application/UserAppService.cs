using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ColaNet.Core.AppService;
using ColaNet.Core.Repositories;
using ColaNet.Models.Entitys;

namespace ColaNet.Web.Application
{
    public class UserAppService : AppService, IUserAppService
    {
        public IRepository<User> _userRepository;

        public UserAppService(IRepository<User> userRepository)
        {
           
            _userRepository = userRepository;           
        }

        public User Add(User entity)
        {
            logManger.Error("测试");
            return _userRepository.Add(entity);
        }
    }
}