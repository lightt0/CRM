using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    [Table("ClientMoral")]
    public class ClientMoral
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le nom est obligatoire"), MaxLength(50)]
        public string nom { get; set; }

        [Required(ErrorMessage = "le numéro de téléphone est obligatoire")]
        public int numTel { get; set; }

        [Required(ErrorMessage = "le numéro de téléphone est obligatoire")]
        public int codeFiscal { get; set; }

        [Required(ErrorMessage = "l'adresse est obligatoire"), MaxLength(50)]
        public string adresse { get; set; }

        [Required(ErrorMessage = "le mail est obligatoire"), MaxLength(255)]
        public string mail { get; set; }

        [Required(ErrorMessage = "le mot de passe est obligatoire"), MaxLength(20)]
        public string password { get; set; }
    }
}
