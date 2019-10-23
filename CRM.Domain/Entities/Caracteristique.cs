using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Caracteristique")]
    public class Caracteristique
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le contenu est obligatoire"), MaxLength(255)]
        public string contenu { get; set; }

        [Required(ErrorMessage = "le titre est obligatoire"), MaxLength(255)]
        public string titre { get; set; }
    }
}
