namespace Hospital.Web.Models.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class SupplierFormModel
    {
        [Required]
        [MinLength(SupplierNameMinLength)]
        [MaxLength(SupplierNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public bool IsImporter { get; set; }
    }
}
