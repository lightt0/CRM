using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.Domain.Entities
{

    [Table("ClientPhysique")]
    public class ClientPhysique
    {
        [Key, Column("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "le champ cin est obligatoire")]
        public int cin { get; set; }

        [Required(ErrorMessage = "le nom est obligatoire"), MaxLength(50)]
        public string nom { get; set; }

        [Required(ErrorMessage = "le prénom est obligatoire"), MaxLength(50)]
        public string prenom { get; set; }

        [Required(ErrorMessage = "le numéro de téléphone est obligatoire")]
        public int numTel { get; set; }

        [Required(ErrorMessage = "la date de naissance est obligatoire")]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "l'adresse est obligatoire"), MaxLength(255)]
        public string adresse { get; set; }

        [Required(ErrorMessage = "le mail est obligatoire")]
        public string mail { get; set; }

        [Required(ErrorMessage = "le mot de passe est obligatoire")]
        public string password { get; set; }
    }
}
