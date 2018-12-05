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
    public class ContractController : Controller
    {
        // GET: Contact
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateContractService();
            var model = service.GetContracts();
            return View(model);
        }
        public ActionResult Create()
        {
            var clientService = CreateClientService();
            var mowerService = CreateMowerService();
            var clients = clientService.GetClients();
            var mowers = mowerService.GetMowers();
            
            ViewBag.ClientId = new SelectList(clients, "ClientId", "ClientName");
            ViewBag.MowerId = new SelectList(mowers, "MowerId", "MowerName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractCreate contract)
        {
            if (!ModelState.IsValid)
            {

            }
            return View(contract);
        }

        private ContractService CreateContractService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContractService(userId);
            return service;
        }
        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }
        private MowerService CreateMowerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MowerService(userId);
            return service;
        }
    }
}