using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Reaction")]
    public class Reaction
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le status est obligatoire")]
        public int status { get; set; }
    }
}
