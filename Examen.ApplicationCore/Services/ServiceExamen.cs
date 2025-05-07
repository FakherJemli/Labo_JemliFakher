using System;
using System.Collections.Generic;
using System.Linq;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;

namespace Examen.ApplicationCore.Services
{
    public class ExamenService : IExamenService
    {
        //liste des bilans 
        private List<Bilan> bilans;
        //liste des infirmiers
        private List<Infirmier> infirmiers;
        //liste des patients
        private List<Patient> patients;



        //Service1
        public ExamenService(List<Bilan> bilans, List<Infirmier> infirmiers, List<Patient> patients)
        {
            this.bilans = bilans != null ? bilans : new List<Bilan>();
            this.infirmiers = infirmiers != null ? infirmiers : new List<Infirmier>();
            this.patients = patients != null ? patients : new List<Patient>();
        }
        //Service2
        public double CalculerMontantTotalBilan(Bilan bilan)
        {
            if (bilan == null || bilan.Analyses == null || bilan.Patient == null) return 0;

            double total = bilan.Analyses.Sum(a => a.PrixAnalyse);
            int count = bilan.Patient.Bilans != null ? bilan.Patient.Bilans.Count : 0;
            return count > 5 ? total * 0.9 : total;
        }

        //Service3
        public double CalculerPourcentageInfirmiersParSpecialite(Specialite specialite)
        {
            if (infirmiers.Count == 0) return 0;
            return Math.Round(infirmiers.Count(i => i.Specialite == specialite) * 100.0 / infirmiers.Count, 2);
        }
        //Service4
        public Dictionary<Bilan, List<Analyse>> RecupererAnalysesAnormales(Patient patient)
        {
            var result = new Dictionary<Bilan, List<Analyse>>();
            if (patient == null || patient.Bilans == null) return result;

            foreach (var bilan in patient.Bilans)
            {
                if (bilan == null || bilan.DatePrelevement.Year != DateTime.Now.Year) continue;

                var analyses = bilan.Analyses != null
                    ? bilan.Analyses.Where(a => a.ValeurAnalyse < a.ValeurMinNormale ||
                                              a.ValeurAnalyse > a.ValeurMaxNormale).ToList()
                    : new List<Analyse>();

                if (analyses.Count > 0) result[bilan] = analyses;
            }
            return result;
        }
        //Service5
        public DateTime RecupererDateDisponibiliteBilan(Bilan bilan)
        {
            if (bilan == null) return DateTime.MinValue;
            if (bilan.Analyses == null || !bilan.Analyses.Any()) return bilan.DatePrelevement;

            return bilan.DatePrelevement.AddDays(bilan.Analyses.Max(a => a.DuréeResultat));
        }
    }
}