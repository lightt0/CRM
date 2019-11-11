using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Data;
using CRM.Domain;
using CRM.Domain.Entities;

namespace Web.Controllers
{
    public class DevisFactureController : Controller
    {

        HttpContextBase HttpContext { get; }

        /* public Facture IFactureService { get; set; }

         public DevisFactureController()
         {

             IFactureService = new Service.Facture();

         }*/
        // GET: Quiz/Create
        /*  public ActionResult Create()
          {
              var l = _ITestervice.GetAll();
              List<TestVM> lo = new List<TestVM>();

              foreach (var item in l)
              {
                  //var _Test = _ITestervice.GetById(item.TestFK);


                  lo.Add(
                      new TestVM
                      {
                          Id_Test = item.Id,
                          Name_Quiz = item.Name_Quiz,
                          Nbr_Point_Total = item.Nbr_Point_Tolal,
                          Nbr_Question = item.Nbr_Question

                      }

                      );

              }
              ViewBag.TestFK = new SelectList(lo, "Id_Test", "Name_Test");
              return View();
          }*/
        // GET: DevisFacture/Create
        /*   public ActionResult affichageAdmin()
           {
               var l = IFactureService.GetAll();
               List<Facture> lo = new List<Facture>();

               foreach (var item in l)
               {
                   lo.Add(
                       new Facture(
                          description = item.description;
                          prixUnitaire = 


                           )
                   return View();
           }*/

    }
}
