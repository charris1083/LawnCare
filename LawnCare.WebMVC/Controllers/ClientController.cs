using LawnCare.Models;
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
            var clientModel = new ClientListItem[0];
            return View(clientModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate client)
        {
            if (!ModelState.IsValid)
            {

            }
            return View(client);
        }
    }
}