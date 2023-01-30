using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(IdDoctor))]
        public virtual Doctor Doctor { get; set; }

        [ForeignKey(nameof(IdPatient))]
        public virtual Patient Patient { get; set; }
    }
}
