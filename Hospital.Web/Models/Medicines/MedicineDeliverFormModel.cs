namespace Hospital.Web.Models.Medicines
{
    using System.ComponentModel.DataAnnotations;

    public class MedicineDeliverFormModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
