using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Domain.Entities;
using Service;
using webuser.Models;

namespace webuser.Controllers
{
    public class reclamationFrontController : Controller
    {
        IReclamationService rs = new ReclamationService();
        //status accceptée
        public ActionResult accepter(int id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Reclamation r = rs.GetById(id);

         
            r.status = "acceptée";


            if (r == null)
                return HttpNotFound();

            rs.Update(r);
            rs.Commit();
            // Service.Dispose();

            return RedirectToAction("Index");
            // TODO: Add delete logic her




        }
        //status refusée
        public ActionResult refuser(int id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Reclamation r = rs.GetById(id);


            r.status = "refusée";


            if (r == null)
                return HttpNotFound();

            rs.Update(r);
            rs.Commit();
          

            return RedirectToAction("Index");
            // TODO: Add delete logic her




        }



        // GET: reclamationFront
        public ActionResult Index()
        {
            var listrec = rs.GetMany();


            var reclamations = new List<rec>();
            foreach (Reclamation e in listrec)
            {
                reclamations.Add(new rec()
                {  id=e.id,
                    objet = e.objet,
                    contenu = e.contenu,
                    type = e.type,
                    dateDebut = System.DateTime.Now,
                    dateFin = System.DateTime.Now,
                    status = e.status,
                    ClientMoralFK = 1,
                    ClientPhysiqueFK = 1,


                });
            }
            return View(reclamations);
        }

        // GET: reclamationFront/Details/5
        public ActionResult Details(int id)
        {
            Reclamation cm = new Reclamation();
            cm = rs.GetById(id);
            rec c = new rec();
            c.type = cm.type;
            c.objet = cm.objet;
            c.status = cm.status;
            c.dateDebut = cm.dateDebut;
            c.dateFin = cm.dateFin;
            c.contenu = cm.contenu;
            ViewBag.id = cm.id;
            return View(c);
        }

        // GET: reclamationFront/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reclamationFront/Create
        [HttpPost]
        public ActionResult Create(rec r, HttpPostedFileBase File)
        {
            if (!ModelState.IsValid || File == null || File.ContentLength == 0)
            {
                RedirectToAction("Create", "~/Views/Shared/_CustomerLayout.cshtml");
            }

            rs.Add(new Reclamation()
            {
                objet = r.objet,
                contenu = r.contenu,
                type = r.type,
                dateDebut = System.DateTime.Now,
                dateFin = System.DateTime.Now,
                status = r.status,
                ClientMoralFK = 1,
                ClientPhysiqueFK = 1
            });
            rs.Commit();

            return View();
        }
    

        // GET: reclamationFront/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: reclamationFront/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,rec r1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(id==null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Reclamation recl = rs.GetById(id);
                    recl.objet = r1.objet;
                    recl.contenu = r1.contenu;
                    recl.status = r1.status;
                    recl.type = r1.type;
                    recl.dateDebut =r1.dateDebut;
                    recl.dateFin = r1.dateFin;

                    if (recl == null)
                        return HttpNotFound();
                    rs.Update(recl);
                    rs.Commit();
                    return RedirectToAction("Index");

                }
                return View(r1);

                
            }
            catch
            {
                return View("~/Views/Shared/Customer.cshtml");
            }
        }

        // GET: reclamationFront/Delete/5
        public ActionResult Delete(int id)
        {
            Reclamation cm = new Reclamation();
            cm = rs.GetById(id);
            rec c = new rec();
            c.type = cm.type;
            c.objet = cm.objet;
            c.status = cm.status;
            c.dateDebut = cm.dateDebut;
            c.dateFin = cm.dateFin;
            c.contenu = cm.contenu;
            return View(c);
        }

        // POST: reclamationFront/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HttpPostedFileBase File, FormCollection collection)
        {
            if (!ModelState.IsValid || File == null || File.ContentLength == 0)
            {
                RedirectToAction("Delete");
            }
             Reclamation R;
            R = rs.GetById(id);

            rs.Delete(R);
            rs.Commit();
            // rs.Dispose();

            return RedirectToAction("Index");
        }

    }
    }


