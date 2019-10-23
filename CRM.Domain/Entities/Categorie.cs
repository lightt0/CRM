using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{

    [Table("Categorie")]
    public class Categorie
    {

        [Key, Column("Id")]
        [Required(ErrorMessage = "le nom est obligatoire"), MaxLength(50)]
        public string nom { get; set; }
    }
}
