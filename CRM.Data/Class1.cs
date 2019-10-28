using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class CrmContext:DbContext
    {
        public CrmContext():base("CRMDB")
        {

        }
        public DbSet<Produit> produits { get; set; }
        public DbSet<Agent> agents { get; set; }
        public DbSet<Caracteristique> caracteristiques { get; set; }
        public DbSet<Categorie> categories { get; set; }
        public DbSet<Ressource> Ressource { get; set; }

    }
}
