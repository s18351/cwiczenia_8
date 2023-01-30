using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Prescription_Medicament
    {
        public int IdPrescription { get; set; }
        public int IdMedicament { get; set; }
        [MaxLength(100)]
        public string Details { get; set; }
        public int Dose { get; set; }
    }
}
