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
    public class OffreController : Controller
    { 
       

        IOffreService cs = new OffreService();
        IProduitService pr = new ProduitService();
        IProdOffService ps = new ProdOffService();
        // GET: Pack
        public ActionResult Index()
        {
            List<OffreModel> lc = new List<OffreModel>();
          
            foreach (var cm in cs.GetAll())
            {
                OffreModel c = new OffreModel();
               

               

                c.nom = cm.nom;
                c.id = cm.id;
                c.nomsousoffre = cm.nomsousoffre;
                c.description = cm.description;
                c.prix = cm.prix;
                lc.Add(c);
            }
            return View(lc);

        }

            // GET: Pack
            public ActionResult Indexfront()
            {
                List<OffreModel> lc = new List<OffreModel>();

                foreach (var cm in cs.GetAll())
                {
                    OffreModel c = new OffreModel();




                    c.nom = cm.nom;
                    c.id = cm.id;
                    c.nomsousoffre = cm.nomsousoffre;
                    c.description = cm.description;
                    c.prix = cm.prix;
                    lc.Add(c);
                }
                return View(lc);

            }

        // GET: Offre/Details/5
        public ActionResult Details(int id)
        {
            List<OffreModel> lc = new List<OffreModel>();
            foreach (var cm in cs.GetAll())
            {
                OffreModel c = new OffreModel();

                c.nom = cm.nom;
                c.id = cm.id;
                c.nomsousoffre = cm.nomsousoffre;
                c.description = cm.description;
                c.prix = cm.prix;
                lc.Add(c);
            }
            return View(lc);
        }

        // GET: Offre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offre/Create
        [HttpPost]
        public ActionResult Create(OffreModel cm)
        {
           
            Offre c = new Offre();
            c.nomsousoffre = cm.nomsousoffre;
            c.prix = cm.prix;
            c.description = cm.description;
            c.nom = cm.nom;


            cs.Add(c);
            cs.Commit();

            return RedirectToAction("Index");
        }

        // POST: Produit/Create
        [HttpPost]
        public JsonResult AjoutProduitAction(int produitId, int offreId)
        {
            Produit produit = new Produit();
            Offre  offre = new Offre();
            ProduitOffre prodoff = new ProduitOffre();


            try
            {
                //ressource =Rs.GetById(ressourceId);
                //Rs.Add(ressource);
                //tache = cs.GetById(tacheId);
                //cs.Add(tache);
                //cs.Commit();
                // tache = cs.GetById(tacheId);
                // ressource = Rs.GetById(ressourceId);
                prodoff.ProduitId = produitId;
                prodoff.OffreId = offreId;
                ps.Add(prodoff);
                ps.Commit();
                // cs.AddResourceToTache(tache, ressource);

                return Json(new { message = "Produit Added" });
            }
            catch (Exception)
            {

                throw;
            }


        }

        // GET: Offre/Edit/5
        public ActionResult Edit(int id)
        {
           
            Offre cm = new Offre();

            cm = cs.Get(t => t.id == id);

            OffreModel c = new OffreModel();
            cm = cs.GetById(id);
            c.nom = cm.nom;         
            c.nomsousoffre = cm.nomsousoffre;
            c.description = cm.description;
            c.prix = cm.prix;

            return View(c);
        }

        // POST: Offre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OffreModel cm)
        {
            Offre o = new Offre();
           
            o = cs.Get(t => t.id == id);
            o.nom = cm.nom;
            o.nomsousoffre = cm.nomsousoffre;
            o.description = cm.description;
            o.prix = cm.prix;
            o.nom = cm.nom;
            cs.Update(o);
            cs.Commit();
            return RedirectToAction("Index");

          

        }

        // GET: Offre/Delete/5
        public ActionResult Delete(int id)
        {
            Offre cm = new Offre();

            cm = cs.Get(t => t.id == id);

            OffreModel c = new OffreModel();
            cm = cs.GetById(id);
            c.nom = cm.nom;         
            c.nomsousoffre = cm.nomsousoffre;
            c.description = cm.description;
            c.prix = cm.prix;

            return View(c);
        }

        // POST: Offre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OffreModel cm)
        {
            Offre o = new Offre();
            o = cs.Get(t => t.id == id);
            cs.Delete(o);
            cs.Commit();
            return RedirectToAction("Index");



        }

        // GET: Offre/Ajout
        public ActionResult Ajout()
        {
            return View();
        }

        // POST: Offre/Ajout
        [HttpPost]
        public ActionResult Ajout(int OffreId, int ProduitId, HttpPostedFileBase File, FormCollection collection)
        {


           if (!ModelState.IsValid || File==null || File.ContentLength == 0)
            {
                RedirectToAction("Ajouter");
            }

            ps.Add(new ProduitOffre()
            {
                ProduitId = ProduitId,
                OffreId = OffreId

            });

            ps.Commit();

            return RedirectToAction("Index");
        }



        }
    }

