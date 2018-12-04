using LawnCare.Models;
using LawnCare.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawnCare.WebMVC.Controllers
{
    public class MowerController : Controller
    {
        // GET: Mower
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MowerService(userId);
            var model = service.GetMowers();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MowerCreate model)
        {
            if (ModelState.IsValid)
            {
            return View();
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MowerService(userId);

            service.CreateMower(model);

            return RedirectToAction("Index");
        }
        
    }
}