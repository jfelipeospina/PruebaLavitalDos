using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        ServiceReference1.Service1Client ser = new ServiceReference1.Service1Client();
        ServiceReference1.vlogin vlogin = new ServiceReference1.vlogin();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ServiceReference1.vlogin vlog)
        {
            string check = ser.UserLogin(vlog);
            if (check == "true")
            {
                Session["Usuario"] = vlog.Usuario.ToString();
                return RedirectToAction("User", "Home");
            }
            else
            {
                TempData["error"] = "<script> alert('Incorrect Username or Password... Please try again')</script>";
                return View();
            }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}