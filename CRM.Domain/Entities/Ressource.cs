using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("ressource")]
    public class Ressource
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le nom d'une ressource est obligatoire"), MaxLength(50)]
        public string nom { get; set; }

        [Required(ErrorMessage = "le type d'une ressource est obligatoire"), MaxLength(20)]
        public string type { get; set; }

        [Required(ErrorMessage = "la quantité est obligatoire")]
        public double quantite { get; set; }
    }
}
