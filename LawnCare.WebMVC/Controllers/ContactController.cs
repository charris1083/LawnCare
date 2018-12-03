using LawnCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawnCare.WebMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [Authorize]
        public ActionResult Index()
        {
            var contractModel = new ContractListItem[0];
            return View(contractModel);
        }
    }
}