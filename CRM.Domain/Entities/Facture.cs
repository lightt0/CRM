using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Facture")]
    public class Facture
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "la description est obligatoire"), MaxLength(255)]
        public string description { get; set; }

        [Required(ErrorMessage = "le prix unitaire est obligatoire")]
        public double prixUnitaire { get; set; }

        [Required(ErrorMessage = "le TVA unitaire est obligatoire")]
        public double tva { get; set; }

        [Required(ErrorMessage = "le prix total est obligatoire")]
        public double prixTotal { get; set; }

        [Required(ErrorMessage = "la date d'une facture est obligatoire")]
        public DateTime dateFacture { get; set; }
    }
}
