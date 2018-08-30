namespace Hospital.Web.Models.Diagnoses
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class DiagnosisFormModel
    {
        [Required]
        [MinLength(DiagnosisTitleMinLength)]
        [MaxLength(DiagnosisTitleMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DiagnosisDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
