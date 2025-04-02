using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Patient
    {
        [Key]
        [StringLength(5, ErrorMessage = "Le code patient doit avoir exactement 5 caractères")]
        public string CodePatient { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Informations supplémentaires")]
        public string Informations { get; set; }

        // Navigation properties
        public virtual ICollection<Bilan> Bilans { get; set; }
    }
}
