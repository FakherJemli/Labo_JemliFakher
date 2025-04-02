using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Bilan
    {
        public string CodeInfirmier { get; set; }
        public string CodePatient { get; set; }
        public DateTime DatePrelevement { get; set; }

        // Foreign keys
        public int AnalyseId { get; set; }

        // Navigation properties
        public virtual Infirmier Infirmier { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Analyse Analyse { get; set; }
    }
}
