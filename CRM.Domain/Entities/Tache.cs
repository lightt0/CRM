using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Tache")]
    public class Tache
    {

        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le nom est obligatoire"), MaxLength(50)]
        public string nom { get; set; }

        [Required(ErrorMessage = "la date de début est obligatoire")]
        public DateTime dateDebut{ get; set; }

        [Required(ErrorMessage = "la date fin est obligatoire")]
        public DateTime dateFin{ get; set; }
    }
}
