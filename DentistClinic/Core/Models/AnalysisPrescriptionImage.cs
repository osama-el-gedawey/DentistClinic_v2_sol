namespace DentistClinic.Core.Models
{
    public class AnalysisPrescriptionImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int AnalysisPrescriptionId { get; set; }
        public virtual AnalysisPrescription? AnalysisPrescription { get; set; }
    }
}
