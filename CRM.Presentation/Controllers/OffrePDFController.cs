using System;
using System.Collections.Generic;
using System.Linq;
using Rotativa;
using System.Web;
using System.Web.Mvc;
using webuser.Models;


namespace webuser.Controllers
{
    public class OffrePDFController : Controller
    {
        // GET: OffrePDF
        public ActionResult Index()
        {
            OffrePDF pm = new OffrePDF();
            ViewBag.listOffres = pm.FindAll();
            return View();
        }
        public ActionResult ExportPDF()
        {
            return new ActionAsPdf("Index")

            {
                FileName = Server.MapPath("~/Contenet/listOffres.pdf")
            };
           
        }
    }
}