using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Devis")]
    public class Devis
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "la quantité est obligatoire")]
        public double quantite { get; set; }

        [Required(ErrorMessage = "le prix unitaire est obligatoire")]
        public double prixUnitaire { get; set; }

        [Required(ErrorMessage = "le prix total est obligatoire")]
        public double prixTotal { get; set; }

        [Required(ErrorMessage = "la date total est obligatoire")]
        public DateTime dateDevis { get; set; }
    }
}
