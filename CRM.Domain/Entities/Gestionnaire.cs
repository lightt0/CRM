using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Gestionnaire")]
    public class Gestionnaire
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le champ cin est obligatoire"), MaxLength(20)]
        public int cin { get; set; }

        [Required(ErrorMessage = "le nom est obligatoire"), MaxLength(20)]
        public string nom { get; set; }

        [Required(ErrorMessage = "le prénom est obligatoire"), MaxLength(20)]
        public string prenom { get; set; }

        [Required(ErrorMessage = "le mail est obligatoire")]
        public string mail { get; set; }

        [Required(ErrorMessage = "le mot de passe est obligatoire")]
        public string password { get; set; }

    }
}
