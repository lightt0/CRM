using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Offre")]
    public class Offre
    {
        [Key, Column("Id")]
        public String nom { get; set; }


    }
}
