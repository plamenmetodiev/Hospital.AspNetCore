namespace Hospital.Web.Models.Patients
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class RegisterPatientFormModel
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
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [MinLength(PatientAddressMinLength)]
        [MaxLength(PatientAddressMaxLength)]
        public string Address { get; set; }

        [Required]
        public bool HasHealthInsurance { get; set; }

        [Display(Name = "Diagnosis")]
        public int DiagnosisId { get; set; }

        public IEnumerable<SelectListItem> Diagnoses { get; set; }

        [Display(Name = "Medicines")]
        public int[] MedicinesIds { get; set; }

        public IEnumerable<SelectListItem> Medicines { get; set; }
    }
}
