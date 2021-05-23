using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        DemoLoginPageEntities entity = new DemoLoginPageEntities();
        public ActionResult Index()
        {
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
        public ActionResult Login(LoginDto model)
        {
            if(model!=null && !string.IsNullOrEmpty( model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                string encryptPass = Convert.ToBase64String(Encoding.UTF8.GetBytes(model.Password));
                User user = entity.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == encryptPass);
                if(user != null)
                {
                    ViewBag.Message = "Welcome " + user.UserName;
                    return View("Index");
                }
                else
                {
                    ViewBag.Message = "User not found";
                    return View();
                }
            }
            return View();
        }
    }
}