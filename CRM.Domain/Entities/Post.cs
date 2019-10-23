using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("Post")]
    public class Post
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le titre est obligatoire"), MaxLength(50)]
        public string titre { get; set; }

        [Required(ErrorMessage = "la date  est obligatoire")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "le titre est obligatoire"), MaxLength(50)]
        public string contenu { get; set; }
    }
}
