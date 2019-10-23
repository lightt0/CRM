using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Produit")]
    public class Produit
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le nom est obligatoire"), MaxLength(50)]
        public string nom { get; set; }

        [Required(ErrorMessage = "le prix est obligatoire")]
        public double prix { get; set; }

        [Required(ErrorMessage = "la description d'un produit est obligatoire"), MaxLength(255)]
        public string description { get; set; }
    }
}
