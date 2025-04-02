using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum Specialite
    {
        Hematologie,
        Biochimie,
        Autre

    }
    public class Infirmier
    {
        [Key]
        [StringLength(5, ErrorMessage = "Le code infirmier doit avoir exactement 5 caractères")]
        public string CodeInfirmier { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        // Navigation properties
        public virtual ICollection<Bilan> Bilans { get; set; }
    }
}
