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
            ClientService service = CreateClientService();
            var model = service.GetClients();

            return View(model);
        }

        private ClientService CreateClientService()
        {
            var clientId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(clientId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model)) 
            {
                TempData["SaveResult"] = "Your client ws created.";
                return RedirectToAction("Index");
            };
            

            ModelState.AddModelError("", "Client coud not be created.");

            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }
        
    }
}