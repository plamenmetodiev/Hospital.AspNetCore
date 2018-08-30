namespace Hospital.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Diagnosis
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DiagnosisTitleMinLength)]
        [MaxLength(DiagnosisTitleMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DiagnosisDescriptionMaxLength)]
        public string Description { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
