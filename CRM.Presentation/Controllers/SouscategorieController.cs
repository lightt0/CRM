
using CRM.Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class SouscategorieController : Controller
    {
        ISousCategorie es = new SousCategorieService();
        ICategorieService ss = new CategorieService();
        public ActionResult ajoutserSouscategorie()
        {
            var categories = ss.GetMany();
            ViewBag.categorie_FK = new SelectList(categories, "nom", "nom");
            return View();

        }

        [HttpPost]
        public ActionResult ajoutserSouscategorie(SousCategorie p, HttpPostedFileBase File)
        {
            if (!ModelState.IsValid || File == null || File.ContentLength == 0)
            {
                RedirectToAction("ajoutserSouscategorie");
            }
            es.Add(new SousCategorie {
                nomC = p.nomC ,
                categorie_FK = p.categorie_FK

            });
            es.Commit();
            return RedirectToAction("ajoutserSouscategorie");
       }
        public ActionResult listeSouscategorie()
        {
            return View(es.GetAll().ToList());
        }
        public ActionResult Delete(String id)
        {
            return View(es.GetById(id));
        }
        [HttpPost]
        public ActionResult Delete(String id , SousCategorie p)
        {
            p = es.GetById(id);
            es.Delete(p);
            es.Commit();
            return RedirectToAction("listeSouscategorie");
            
        }

    }
}
