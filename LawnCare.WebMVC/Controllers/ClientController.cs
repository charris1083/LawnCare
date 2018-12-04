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
    public class ClientController : Controller
    {
        // GET: Client
        [Authorize]
        public ActionResult Index()
        {
            var clientId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(clientId);
            var model = service.GetClients();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid)
            {
            return View();
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);

            service.CreateClient(model);

            return RedirectToAction("Index");
        }
        
    }
}