using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Analyse
    {
        public int AnalyseId { get; set; }
        public string Nom { get; set; }
        public int DureeResultat { get; set; }
        public decimal ValeurAnalyse { get; set; }
        public decimal ValeurMaxNormale { get; set; }
        public decimal ValeurMinNormale { get; set; }

        // Foreign key
        public int LaboratoireId { get; set; }

        // Navigation properties
        public virtual Laboratoire Laboratoire { get; set; }
        public virtual ICollection<Bilan> Bilans { get; set; }
    }
}
