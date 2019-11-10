using CRM.Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CategorieController : Controller
    {
        ICategorieService es = new CategorieService();
        // GET: Categorie
        public ActionResult ListCategorie()
        {
            var l =es.GetAll().ToList<Categorie>();
            return View(l);
        }
        public ActionResult AjouterCategorie()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AjouterCategorie(Categorie e, HttpPostedFileBase File)
        {
            //ce if va vérifier si le modéle est valide et que le file n'est pas vide(ou null)
            if (!ModelState.IsValid || File == null || File.ContentLength == 0)
            {
                RedirectToAction("AjouterCategorie");
            }
            es.Add(new Categorie
            {
                nom = e.nom
            });
            es.Commit();

            return RedirectToAction("ListCategorie");
        }

        public ActionResult Delete(String id)
        {

            return View(es.GetById(id));
        }
        [HttpPost]
        public ActionResult Delete(String id, Categorie p)
        {
            p = es.GetById(id);
            es.Delete(p);
           es.Commit();
            return RedirectToAction("ListCategorie");

        }
    }
}
