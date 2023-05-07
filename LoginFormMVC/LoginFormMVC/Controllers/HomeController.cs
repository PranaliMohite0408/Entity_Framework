using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginFormMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if(Session["Username"] == null)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}