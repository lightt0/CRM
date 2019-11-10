using CRM.Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webuser.Controllers
{
    public class HomeController : Controller
    {
        ICategorieService ss = new CategorieService();
        ISousCategorie es = new SousCategorieService();
        IProduitService ep = new ProduitService();
        public ActionResult Index()
        {
            var l = ss.GetAll().ToList();
            var s = es.GetAll().ToList();
            var p = ep.GetAll().ToList();
            var b = ep.GetAll().OrderBy(o => o.vu).ToList();
            List<Produit> so = new List<Produit>();
            List<Produit> TOP = new List<Produit>();
            p.Reverse();
            b.Reverse();
            var i = 0;
            foreach (var item in p)
            {

                if (i < 12)
                {
                    i++;
                    so.Add(item);

                }
                else
                {
                    break;
                }
            }
            i = 0;
            foreach (var item in b)
            {

                if (i < 10)
                {
                    i++;
                    TOP.Add(item);

                }
                else
                {
                    break;
                }
            }
            var x = new webuser.Models.Categorie
            {
                categories = l,
                SousCategories = s,
                New_Produits = so,
                All_Produits = p,
                Produit_TOP_View = TOP
            };

            return View("Index", "~/Views/Shared/_CustomerLayout.cshtml", x);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Listdesproduit(String id)
        {
            ICategorieService ss = new CategorieService();
            ISousCategorie es = new SousCategorieService();
            IProduitService ep = new ProduitService();

            var l = ss.GetAll().ToList();
            var s = es.GetAll().ToList();
            var p = ep.GetAll().ToList();
            List<Produit> soe = new List<Produit>();
            List<Produit> so = new List<Produit>();
            p.Reverse();
            var i = 0;
            foreach (var item in p)
            {

                if (i < 12)
                {
                    i++;
                    so.Add(item);

                }
                else
                {
                    break;
                }
            }
            foreach (var item in p)
            {
                if(item.categorieFK.Equals(id))
                { soe.Add(item); }
            }
                var x = new webuser.Models.Categorie
            {
                categories = l,
                SousCategories = s,
                New_Produits = so,
                All_Produits = p,
                Produit_cat = soe
                };
            return View("Listdesproduit", "~/Views/Shared/_CustomerLayout.cshtml", x);
        }
        public ActionResult produit(int id)
        {
            ICategorieService ss = new CategorieService();
            ISousCategorie es = new SousCategorieService();
            IProduitService ep = new ProduitService();

            var l = ss.GetAll().ToList();
            var s = es.GetAll().ToList();
            var p = ep.GetAll().ToList();
            var r = ep.GetById(id);
            r.vu = r.vu + 1;
            ep.Update(r);
            ep.Commit();
            List<Produit> soe = new List<Produit>();
            List<Produit> so = new List<Produit>();
            p.Reverse();
            var i = 0;
            foreach (var item in p)
            {

                if (i < 12)
                {
                    i++;
                    so.Add(item);

                }
                else
                {
                    break;
                }
            }
            foreach (var item in p)
            {
                if (item.categorieFK.Equals(id))
                { soe.Add(item); }
            }
            var x = new webuser.Models.Categorie
            {
                categories = l,
                SousCategories = s,
                New_Produits = so,
                All_Produits = p,
                Produit_cat = soe,
                produit = r 
            };
            return View("produit", "~/Views/Shared/_CustomerLayout.cshtml", x);
        }


    }
}
