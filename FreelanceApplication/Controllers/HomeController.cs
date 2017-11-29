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

        public ActionResult Index(int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<FreelanceDescription> descriptions = _context.FreelanceDescriptions.OrderBy(x=>x.CompanyName).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = _context.FreelanceDescriptions.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, FreelanceDescriptions = descriptions };
            return View(ivm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}