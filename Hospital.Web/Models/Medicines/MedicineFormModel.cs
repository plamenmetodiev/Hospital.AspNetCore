namespace Hospital.Web.Models.Medicines
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class MedicineFormModel
    {
        [Required]
        [MinLength(MedicineTitleMinLength)]
        [MaxLength(MedicineTitleMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; }
    }
}
