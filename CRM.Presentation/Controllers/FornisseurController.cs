using CRM.Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using webuser.Models;

namespace webuser.Controllers
{
    public class FornisseurController : Controller
    {
        IFornisseurService es = new FornisseurService();
        public IProduitService p = new ProduitService();
        public ActionResult Listefornisseur()
        {
            var l = es.GetAll().ToList<CRM.Domain.Entities.Fournisseur>();
            List<webuser.Models.Fournisseur> h = new List<Models.Fournisseur>();
            foreach (var item in l)
            {
                h.Add(new webuser.Models.Fournisseur
                {
                    id = item.id,
                    nom = item.nom,
                    mail = item.mail,
                    numTel = item.numTel,
                    NomProduit = p.GetById(item.nomProduit).nom

                });


            }


            return View(h);
        }
        public ActionResult AjouterFourniseur()
        {
            var Produit = p.GetMany().ToList();
            ViewBag.nomProduit = new SelectList(Produit, "id", "nom");
            return View();

        }
        [HttpPost]
        public ActionResult AjouterFourniseur(CRM.Domain.Entities.Fournisseur e, HttpPostedFileBase File)
        {
            if (!ModelState.IsValid || File == null || File.ContentLength == 0)
            {
                RedirectToAction("AjouterFourniseur");
            }
            es.Add(new CRM.Domain.Entities.Fournisseur
            {
                nom = e.nom,
                mail = e.mail,
                numTel = e.numTel,
                nomProduit = e.nomProduit

            });
            es.Commit();

            return RedirectToAction("Listefornisseur");

        }
        public ActionResult Delete(int id)
        {
            return View(es.GetById(id));
        }

        // POST: Fornisseur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CRM.Domain.Entities.Fournisseur p)
        {
            p = es.GetById(id);
            es.Delete(p);
            es.Commit();
            return RedirectToAction("Listefornisseur");
        }
        
        public ActionResult EnvoyerMail ()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EnvoyerMail(int id, Mail p)
        {
            var x = es.GetById(id).mail;
            MailMessage mm = new MailMessage( "bassem.mnif@esprit.tn", x);
            mm.Subject = p.Objet;
            mm.Body = p.Body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("bassem.mnif@esprit.tn","183JMT0587");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            return RedirectToAction("Listefornisseur");
        }


    }
}