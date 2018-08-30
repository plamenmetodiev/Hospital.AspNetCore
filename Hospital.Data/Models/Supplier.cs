namespace Hospital.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [MinLength(SupplierNameMinLength)]
        [MaxLength(SupplierNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public bool IsImporter { get; set; }

        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
    }
}
