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
    public class PointOfProspectionController : Controller
    {
        IPointOfProspectionService cs = new PointOfProspectionService();
        // GET: PointOfProspection
        public ActionResult Index()
        {
            List<PointOfProspectionModel> lc = new List<PointOfProspectionModel>();
            foreach (var cm in cs.GetAll())
            {
                PointOfProspectionModel c = new PointOfProspectionModel();
                c.id = cm.id;
                c.nom = cm.nom;
                c.Adress = cm.Adress;
                c.Type = cm.Type;
                lc.Add(c);
            }
            return View(lc);
        }

        // GET: PointOfProspection/Details/5
        public ActionResult Details(int id)
        {
            PointOfProspection cm = new PointOfProspection();
            PointOfProspectionModel c = new PointOfProspectionModel();
            cm = cs.Get(t => t.id == id);

            c.Adress = cm.Adress;
            c.nom = cm.nom;
            c.Type = cm.Type;
            ViewBag.id = cm.id;


            return View(c);
        }

        // GET: PointOfProspection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PointOfProspection/Create
        [HttpPost]
        public ActionResult Create(PointOfProspectionModel cm)
        {
            PointOfProspection c = new PointOfProspection();

            c.id = cm.id;

            c.Adress = cm.Adress;
            c.nom = cm.nom;
            c.Type = cm.Type;



            cs.Add(c);
            cs.Commit();
            return View("Index", "~/Views/Shared/_CustomerLayout.cshtml");
        }

        // GET: PointOfProspection/Edit/5
        public ActionResult Edit(int id)
        {
            PointOfProspection cm = new PointOfProspection();

            cm = cs.Get(t => t.id == id);
            PointOfProspectionModel c = new PointOfProspectionModel();
            c.id = cm.id;
            c.nom = cm.nom;
            c.Adress = cm.Adress;
            
            c.Type = cm.Type;

            return View(c);
        }

        // POST: PointOfProspection/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PointOfProspectionModel cm)
        {
            PointOfProspection c = new PointOfProspection();
            c = cs.Get(t => t.id == id);
            c.id = cm.id;

            c.Adress = cm.Adress;
            c.nom = cm.nom;
            c.Type = cm.Type;


            cs.Update(c);
            cs.Commit();
            return RedirectToAction("Index");
        
    }

        // GET: PointOfProspection/Delete/5
        public ActionResult Delete(int id)
        {
            PointOfProspection cm = new PointOfProspection();

            cm = cs.Get(t => t.id == id);
            PointOfProspectionModel c = new PointOfProspectionModel();
            c.id = id;

            c.Adress = cm.Adress;
            c.nom = cm.nom;
            c.Type = cm.Type;

            return View(c);
        }

        // POST: PointOfProspection/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            PointOfProspection c = new PointOfProspection();
            c = cs.Get(t => t.id == id);
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("Index");
        }
    }
    
}
