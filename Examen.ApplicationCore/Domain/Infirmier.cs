using System.ComponentModel.DataAnnotations;

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
        public int InfirmierId { get; set; }
        public string NomComplet { get; set; }
        public Specialite Specialite { get; set; }

        // many bilans
        public ICollection<Bilan> Bilans { get; set; }

        //many patients
        public ICollection<Patient> Patients { get; set; }
    }
}