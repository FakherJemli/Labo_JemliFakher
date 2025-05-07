namespace Examen.ApplicationCore.Domain
{
    public class Analyse
    {
        public int AnalyseId { get; set; }
        public int DuréeResultat { get; set; }
        public double PrixAnalyse { get; set; }
        public string TypeAnalyse { get; set; }
        public float ValeurAnalyse { get; set; }
        public float ValeurMaxNormale { get; set; }
        public float ValeurMinNormale { get; set; }

        // 1 bilan 
        public Bilan Bilan { get; set; }
    }
}