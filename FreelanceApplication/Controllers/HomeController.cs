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

        public ActionResult Index(string title, string city, double? minPrice, double? maxPrice, int page = 1)
        {
            IQueryable<FreelanceDescription> fd = _context.FreelanceDescriptions;
            if (!String.IsNullOrEmpty(title) && !title.Equals("Все"))
            {
                fd = fd.Where(x => x.Title == title);
            }
            if (!String.IsNullOrEmpty(city) && !city.Equals("Все"))
            {
                fd = fd.Where(p => p.City == city);
            }
            //if (maxPrice != 0 && minPrice != 0)
            //{
            //    fd = fd.Where(x => Convert.ToDouble(x.Price) <= maxPrice && Convert.ToDouble(x.Price) >= minPrice);
            //}
            var pageSize = 3; // количество объектов на страницу
            IEnumerable<FreelanceDescription> descriptions = fd.OrderBy(x=>x.CompanyName).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = fd.Count() };
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