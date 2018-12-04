using LawnCare.Models;
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
            var contractModel = new ContractListItem[0];
            return View(contractModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractCreate contract)
        {
            if (ModelState.IsValid)
            {

            }
            return View(contract);
        }
    }
}