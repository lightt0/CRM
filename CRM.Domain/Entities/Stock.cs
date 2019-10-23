using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{

    [Table("Stock")]
    public class Stock
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "la quantité entrante est obligatoire")]
        public double QteEntrante { get; set; }

        [Required(ErrorMessage = "la quantité sortante est obligatoire")]
        public double QteSortante { get; set; }
    }
}
