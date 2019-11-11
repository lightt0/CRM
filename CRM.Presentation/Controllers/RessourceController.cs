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
    public class RessourceController : Controller
    {
        IRessourceService cs = new RessourceService();
        // GET: Ressource
        public ActionResult Index()
        {
            List<RessourceModel> lc = new List<RessourceModel>();
            foreach (var cm in cs.GetAll())
            {
                RessourceModel c = new RessourceModel();
                c.id = cm.id;

                c.nom = cm.nom;

                c.type = cm.type;
                c.quantite = cm.quantite;
                c.etat = cm.etat;
                lc.Add(c);
            }
            return View(lc);
        }

        // GET: Ressource/Details/5
        public ActionResult Details(int id)
        {

            Ressource cm = new Ressource();
            RessourceModel c = new RessourceModel();
            cm = cs.Get(t => t.id == id);
            c.nom = cm.nom;
            c.quantite = cm.quantite;
            c.type = cm.type;
            c.etat=cm.etat;
            ViewBag.id = cm.id;


            return View(c);
        }

        // GET: Ressource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ressource/Create
        [HttpPost]
        public ActionResult Create(RessourceModel cm)
        {
            Ressource c = new Ressource();

            c.id = cm.id;
            c.nom = cm.nom;
            c.quantite = cm.quantite;
            c.type = cm.type;
            c.etat = cm.etat;
            


            cs.Add(c);
            cs.Commit();
            return View("Index", "~/Views/Shared/_CustomerLayout.cshtml");

        
        }
       
        // GET: Ressource/Edit/5
        public ActionResult Edit(int id)
        {
            Ressource cm = new Ressource();

            cm = cs.Get(t => t.id == id);
            RessourceModel c = new RessourceModel();
            c.id = id;
            c.nom = cm.nom;
            c.quantite = cm.quantite;
            c.type = cm.type;

            c.etat = cm.etat;

            return View(c);
        }

        // POST: Ressource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RessourceModel cm)
        {
            Ressource c = new Ressource();
            c = cs.Get(t => t.id == id);
            c.nom = cm.nom;
            c.quantite = cm.quantite;
            c.type = cm.type;


            c.etat = cm.etat;

            cs.Update(c);
            cs.Commit();
            return RedirectToAction("Index");


        }

        // GET: Ressource/Delete/5
        public ActionResult Delete(int id)
        {
            Ressource cm = new Ressource();

            cm = cs.Get(t => t.id == id);
            RessourceModel c = new RessourceModel();
            c.id = id;
            c.nom = cm.nom;
            c.quantite = cm.quantite;
            c.type = cm.type;

            c.etat = cm.etat;

            return View(c);
        }

        // POST: Ressource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RessourceModel cm)
        {
            Ressource c = new Ressource();
            c = cs.Get(t => t.id == id);
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("Index");
        }
    }
}
