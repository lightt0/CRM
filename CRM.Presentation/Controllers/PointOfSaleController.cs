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
    public class PointOfSaleController : Controller
    {

        IPointOfSaleService cs = new PointOfSaleService();
        // GET: PointOfSale
        public ActionResult Index()
        {
            List<PointOfSaleModel> lc = new List<PointOfSaleModel>();
            foreach (var cm in cs.GetAll())
            {
                PointOfSaleModel c = new PointOfSaleModel();
                c.id = cm.id;
                c.nom = cm.nom;
                c.Adress = cm.Adress;

                c.phone = cm.phone;
                c.Type = cm.Type;
                lc.Add(c);
            }
            return View(lc);
        }

        // GET: PointOfSale/Details/5
        public ActionResult Details(int id)
        {

            PointOfSale cm = new PointOfSale();
            PointOfSaleModel c = new PointOfSaleModel();
            cm = cs.Get(t => t.id == id);

            c.Adress = cm.Adress;
            c.nom = cm.nom;
            c.phone = cm.phone;
            c.Type = cm.Type;
            ViewBag.id = cm.id;


            return View(c);

        }

        // GET: PointOfSale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PointOfSale/Create
        [HttpPost]
        public ActionResult Create(PointOfSale cm)
        {
            PointOfSale c = new PointOfSale();

            c.id = cm.id;

            c.Adress = cm.Adress;
            c.nom = cm.nom;
            c.phone = cm.phone;
            c.Type = cm.Type;



            cs.Add(c);
            cs.Commit();
            return View("Index", "~/Views/Shared/_CustomerLayout.cshtml");
        }

        // GET: PointOfSale/Edit/5
        public ActionResult Edit(int id)
        {
            PointOfSale cm = new PointOfSale();

            cm = cs.Get(t => t.id == id);
            PointOfSaleModel c = new PointOfSaleModel();
            c.id = cm.id;
            c.nom = cm.nom;
            c.Adress = cm.Adress;

            c.phone = cm.phone;
            c.Type = cm.Type;

            return View(c);
        }

        // POST: PointOfSale/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PointOfSale cm)
        {
            PointOfSale c = new PointOfSale();
            c = cs.Get(t => t.id == id);
            c.id = cm.id;

            c.Adress = cm.Adress;
            c.nom = cm.nom;
            c.phone = cm.phone;
            c.Type = cm.Type;


            cs.Update(c);
            cs.Commit();
            return RedirectToAction("Index");
        }

        // GET: PointOfSale/Delete/5
        public ActionResult Delete(int id)
        {
            PointOfSale cm = new PointOfSale();

            cm = cs.Get(t => t.id == id);
            PointOfSaleModel c = new PointOfSaleModel();
            c.id = id;

            c.Adress = cm.Adress;
            c.nom = cm.nom;
            c.phone = cm.phone;
            c.Type = cm.Type;

            return View(c);
        }

        // POST: PointOfSale/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            PointOfSale c = new PointOfSale();
            c = cs.Get(t => t.id == id);
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("Index");
        }
    }
}
