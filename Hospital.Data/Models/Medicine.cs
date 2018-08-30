namespace Hospital.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Medicine
    {
        public int Id { get; set; }

        [Required]
        [MinLength(MedicineTitleMinLength)]
        [MaxLength(MedicineTitleMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public List<PatientMedicine> Patients { get; set; } = new List<PatientMedicine>();
    }
}
