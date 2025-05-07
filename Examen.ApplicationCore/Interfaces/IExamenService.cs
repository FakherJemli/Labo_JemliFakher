using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IExamenService
    {
        double CalculerMontantTotalBilan(Bilan bilan);
        double CalculerPourcentageInfirmiersParSpecialite(Specialite specialite);
        Dictionary<Bilan, List<Analyse>> RecupererAnalysesAnormales(Patient patient);
        DateTime RecupererDateDisponibiliteBilan(Bilan bilan);
    }
}
