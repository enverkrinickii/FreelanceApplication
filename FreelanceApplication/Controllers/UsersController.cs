using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreelanceApplication.Models;
using Microsoft.AspNet.Identity;

namespace FreelanceApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context = new ApplicationContext();
        // GET: Users
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            return View(_context.Users.Where(x=>x.Id == id));
        }
    }
}