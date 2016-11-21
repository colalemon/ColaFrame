using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ColaNet.Core.Repositories;
using ColaNet.Models.Entitys;
using ColaNet.Web.Application;
namespace ColaNet.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserAppService _userAppService;


        public HomeController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public ActionResult Index()
        {
            var ii = _userAppService.Add(new User() { Name="陈乐乐",IsSoftDelete=false});

            var ii1 = _userAppService.Get(60);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}