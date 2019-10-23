using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Agent")]
    public class Agent
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le nom est obligatoire"), MaxLength(50)]
        public string nom { get; set; }

        [Required(ErrorMessage = "le prénom est obligatoire"), MaxLength(50)]
        public string prenom { get; set; }

        [Required(ErrorMessage = "le type est obligatoire"), MaxLength(50)]
        public string type { get; set; }

        [Required(ErrorMessage = "l'heure du travail est obligatoire")]
        public int heureTravail { get; set; }

        [Required(ErrorMessage = "le status est obligatoire"), MaxLength(50)]
        public string status { get; set; }

        [Required(ErrorMessage = "le numéro du téléphone est obligatoire")]
        public int numTel { get; set; }
    }
}
