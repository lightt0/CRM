using CRM.Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SousCategorie = CRM.Domain.Entities.SousCategorie;

namespace Web.Controllers
{
    public class ProduitController : Controller
    {
        public IProduitService _IProduitservice { get; set; }
        public  ISousCategorie es = new SousCategorieService();
        public ProduitController()
        {
            _IProduitservice = new ProduitService();
           
        }
        public ActionResult listdesproduits()
        {
            var l = _IProduitservice.GetAll().ToList<Produit>();
          
         


            return View(l);
        }
        public ActionResult Createproduit()
        {
            var categories = es.GetMany();
            ViewBag.categorieFK = new SelectList(categories, "nomC", "nomC");
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Createproduit(Produit p, HttpPostedFileBase file )
        {
            p.image = file.FileName;
            p.vu = 0;
            _IProduitservice.Add(p);
            _IProduitservice.Commit();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/images/"), file.FileName);
                file.SaveAs(path);
            }
            return RedirectToAction("listdesproduits");


            
        }
        
        public ActionResult Supprimerproduit(int id)
        {
            return View(_IProduitservice.GetById(id));
        }
        [HttpPost]
        public ActionResult Supprimerproduit(int id, Produit p)
        {
            p = _IProduitservice.GetById(id);
            _IProduitservice.Delete(p);
            _IProduitservice.Commit();
            return RedirectToAction("listdesproduits");
        }
        public ActionResult Modifierproduit(int id)
        {
            var categories = es.GetMany();
            ViewBag.categorieFK = new SelectList(categories, "nomC", "nomC");
            return View(_IProduitservice.GetById(id));
        }
        [HttpPost]
        public ActionResult Modifierproduit(int id, Produit p)
        {
          Produit  pr = _IProduitservice.GetById(id);
            //var o = new Produit{
            //    nom = p.nom,
            //    prix= p.prix ,
            //    qteP = p.qteP ,
            //    description = p.description,
            //    image = p.image,
            //    categorieFK = p.categorieFK
            //};
            pr.nom = p.nom;
            pr.prix = p.prix;
            pr.qteP = p.qteP;
            pr.description = p.description;
            pr.image = p.image;
            pr.categorieFK = p.categorieFK;
            pr.vu = p.vu;

            _IProduitservice.Update(pr);
            _IProduitservice.Commit();

            return RedirectToAction("listdesproduits");

        }

    }     
}
