namespace Hospital.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [MinLength(PatientNamesMinLength)]
        [MaxLength(PatientNamesMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(PatientNamesMinLength)]
        [MaxLength(PatientNamesMaxLength)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [MinLength(PatientAddressMinLength)]
        [MaxLength(PatientAddressMaxLength)]
        public string Address { get; set; }

        [Required]
        public bool HasHealthInsurance { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? DeregistrationDate { get; set; }

        [Required]
        public string DoctorId { get; set; }

        public User Doctor { get; set; }

        [Required]
        public int DiagnosisId { get; set; }

        public Diagnosis Diagnosis { get; set; }

        public IEnumerable<PatientMedicine> Medicines { get; set; } = new List<PatientMedicine>();
    }
}
