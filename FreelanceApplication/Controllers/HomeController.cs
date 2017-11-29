using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreelanceApplication.Models;

namespace FreelanceApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _context = new ApplicationContext();

        public ActionResult Index()
        {
            return View(_context.FreelanceDescriptions);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}