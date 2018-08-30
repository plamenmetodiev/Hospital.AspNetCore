namespace Hospital.Web.Models.Patients
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class EditPatientFormModel
    {
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
    }
}
