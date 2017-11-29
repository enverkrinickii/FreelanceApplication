using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FreelanceApplication.Models;
using Microsoft.AspNet.Identity;

namespace FreelanceApplication.Controllers
{
    public class FreelanceDescriptionsController : Controller
    {
        private readonly ApplicationContext _context = new ApplicationContext();

        [Authorize(Roles = "freelancer")]
        public async Task<ActionResult> Index()
        {
            var id = User.Identity.GetUserId();
            var freelanceDescriptions = _context.FreelanceDescriptions.Where(x=>x.UserId == id);
            return View(await freelanceDescriptions.ToListAsync());
        }

        [Authorize(Roles = "freelancer")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelanceDescription freelanceDescription = await _context.FreelanceDescriptions.FindAsync(id);
            if (freelanceDescription == null)
            {
                return HttpNotFound();
            }
            return View(freelanceDescription);
        }

        [Authorize(Roles = "freelancer")]
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CompanyName,ContactEmail,City,Title,Description,Price,UserId")] FreelanceDescription freelanceDescription)
        {
            if (ModelState.IsValid)
            {
                _context.FreelanceDescriptions.Add(freelanceDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(freelanceDescription);
        }

        [Authorize(Roles = "freelancer")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelanceDescription freelanceDescription = await _context.FreelanceDescriptions.FindAsync(id);
            if (freelanceDescription == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(_context.Users, "Id", "Email", freelanceDescription.UserId);
            return View(freelanceDescription);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CompanyName,ContactEmail,City,Title,Description,Price,UserId")] FreelanceDescription freelanceDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(freelanceDescription).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(_context.Users, "Id", "Email", freelanceDescription.UserId);
            return View(freelanceDescription);
        }

        [Authorize(Roles = "freelancer")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelanceDescription freelanceDescription = await _context.FreelanceDescriptions.FindAsync(id);
            if (freelanceDescription == null)
            {
                return HttpNotFound();
            }
            return View(freelanceDescription);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FreelanceDescription freelanceDescription = await _context.FreelanceDescriptions.FindAsync(id);
            _context.FreelanceDescriptions.Remove(freelanceDescription ?? throw new InvalidOperationException());
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
