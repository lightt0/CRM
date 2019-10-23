using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Reclamation")]
    public class Reclamation
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "l'objet est obligatoire"), MaxLength(50)]
        public string objet { get; set; }

        [Required(ErrorMessage = "le contenu est obligatoire"), MaxLength(255)]
        public string contenu { get; set; }

        [Required(ErrorMessage = "l'objet est obligatoire"), MaxLength(20)]
        public string type { get; set; }

        [Required(ErrorMessage = "le champ date est obligatoire")]
        public DateTime dateDebut { get; set; }

        [Required(ErrorMessage = "le champ date est obligatoire")]
        public DateTime dateFin { get; set; }

        [Required(ErrorMessage = "le champ status est obligatoire"), MaxLength(50)]
        public string status { get; set; }
    }
}
