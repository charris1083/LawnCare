using LawnCare.Models;
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
            var mowerModel = new MowerListItem[0];
            return View(mowerModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MowerCreate mower)
        {
            if (ModelState.IsValid)
            {

            }
            return View(mower);
        }
    }
}