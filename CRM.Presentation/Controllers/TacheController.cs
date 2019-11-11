using CRM.Data;
using CRM.Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webuser.Models;
using System.Net.Mail;


namespace webuser.Controllers
{

    public class TacheController : Controller
    {

        ITacheService cs = new TacheService();
        IRessourceService Rs = new RessourceService();
        ITachRessourceService TR = new TachRessourceService();
        // GET: Tache
        public ActionResult Index()
        {
            List<TacheModel> lc = new List<TacheModel>();
            foreach (var cm in cs.GetAll())
            {
                TacheModel c = new TacheModel();
                c.id = cm.id;
                c.dateDebut = cm.dateDebut;
                c.dateFin = cm.dateFin;
                c.nom = cm.nom;
                ViewBag.id = cm.id;

                lc.Add(c);
            }
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("mahmoud.chebil@esprit.tn");
                mail.To.Add("mahmoud.chebil@esprit.tn");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("abderrahmen.elhadjsalah@esprit.tn", "Abdou1395-");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw;
            }
            //smtpClient.Send(mail);
            return View(lc);
        }

        // GET: Tache/Details/5
        public ActionResult Details(int id)
        {

            Tache cm = new Tache();
            TacheModel c = new TacheModel();
            cm = cs.Get(t => t.id == id);
            c.dateDebut = cm.dateDebut;
            c.dateFin = cm.dateFin;
            c.nom = cm.nom;
            ViewBag.id = cm.id;


            return View(c);
        }

        // GET: Tache/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tache/Create
        [HttpPost]
        public ActionResult Create(TacheModel cm)
        {
            Tache c = new Tache();

            c.id = cm.id;
            c.dateDebut = cm.dateDebut;
            c.dateFin = cm.dateFin;
            c.nom = cm.nom;



            cs.Add(c);
            cs.Commit();
            return View();

        }
        // POST: Tache/Create
        [HttpPost]
        public JsonResult AjoutRessourceAction(int ressourceId, int tacheId, int q)
        {
                Ressource res = new Ressource();
                TachRessource tachRs = new TachRessource();

                tachRs.quantite = q;
                tachRs.RessourceId = ressourceId;
                tachRs.TacheId = tacheId;
                res=Rs.GetById(ressourceId);
            if(res.quantite >= q)
            { 
                res.quantite = res.quantite - q;
                if(res.quantite==0)
                {
                    res.etat = (EtatRs)2;
                }
                var newQte = res.quantite;
                Rs.Update(res);
                Rs.Commit();
                TR.Add(tachRs);
                TR.Commit();
                return Json(new { qte = newQte });
            }
            // cs.AddResourceToTache(tache, ressource);


            return Json(new { qte = res.quantite });


        }
        // GET: Tache/AjoutRessource
        public ActionResult AjoutRessource()
        {
           
            ViewBag.Ressource = Rs.GetAll();
            
            return View();
        }
        // GET: Tache
        public ActionResult AfficherTacheRessource(int id)
        {
            List<RessourceQuantiteModel> lc = new List<RessourceQuantiteModel>();
                
            foreach (var cm in TR.GetAll())
            {
                TachRessource c = new TachRessource();
                if(cm.TacheId == id)
                {
                    ViewBag.id = cm.TacheId;
                       int R1;
                    R1 = cm.RessourceId;
                   
                    foreach (var cm1 in Rs.GetAll())
                    {
                        if(cm.RessourceId==cm1.id)
                        {
                            RessourceQuantiteModel c2 = new RessourceQuantiteModel();
                            c2.id = cm1.id;

                            c2.nom = cm1.nom;

                            c2.type = cm1.type;
                            c2.quantite = cm1.quantite;
                            c2.quantiteTache = cm.quantite;
                           lc.Add(c2);
                        }
                    }
                }
                
               
               
            }
            return View(lc);
        }
     

        public ActionResult DeleteTacheRessource(int idTache,int idRessource)
        {
            Ressource c = new Ressource();

            foreach (var cm1 in TR.GetAll())
            {
                if (cm1.RessourceId == idRessource&& cm1.TacheId== idTache)
                {
                    c = Rs.GetById(idRessource);
                    c.quantite = c.quantite + cm1.quantite;
                    Rs.Update(c);
                    Rs.Commit();
                    TR.Delete(cm1);
                    TR.Commit();
                }
            }
            
            return RedirectToAction("Index");
        }
        // GET: Tache/Edit/5
        public ActionResult Edit(int id)
        {
            Tache cm = new Tache();

            cm = cs.Get(t => t.id == id);
            TacheModel c = new TacheModel();
            c.id = id;
            c.dateDebut = cm.dateDebut;
            c.dateFin = cm.dateFin;
            c.nom = cm.nom;
            return View(c);
        }

        // POST: Tache/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,  TacheModel cm)
        {
            Tache c = new Tache();
            c = cs.Get(t => t.id == id);
            c.dateDebut = cm.dateDebut;
            c.dateFin = cm.dateFin;
            c.nom = cm.nom;


            cs.Update(c);
            cs.Commit();
            return RedirectToAction("Index");

        }

        // GET: Tache/Delete/5
        public ActionResult Delete(int id)
        {
            Tache cm = new Tache();

            cm = cs.Get(t => t.id == id);
            TacheModel c = new TacheModel();
            c.id = id;
            c.dateDebut = cm.dateDebut;
            c.dateFin = cm.dateFin;
            c.nom = cm.nom;

            return View(c);
        }

        // POST: Tache/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Tache c = new Tache();
            c = cs.Get(t => t.id == id);
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("Index");
        }

        
    }

}
