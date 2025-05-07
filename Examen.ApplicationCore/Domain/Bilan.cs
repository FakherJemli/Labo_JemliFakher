namespace Examen.ApplicationCore.Domain
{
    public class Bilan
    {
        public DateTime DatePrelevement { get; set; }
        public string EmailMedecin { get; set; }
        public bool Paye { get; set; }

        // 1 infirmer
        public Infirmier Infirmier { get; set; }

        //1 patient
        public Patient Patient { get; set; }

        //many analyses
        public ICollection<Analyse> Analyses { get; set; }

        // Propriétés pour les clés étrangères
        public int InfirmierId { get; set; }
        public string CodePatient { get; set; }
    }
}