using CRM.Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webuser.Models;

namespace webuser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
        IOffreService cs = new OffreService();
            var l = cs.GetAll().ToList();
            

           

            return View("Index", "~/Views/Shared/_CustomerLayout.cshtml", l);
        }

        public ActionResult About()
        {

            return View("About", "~/Views/Shared/Customer.cshtml");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}