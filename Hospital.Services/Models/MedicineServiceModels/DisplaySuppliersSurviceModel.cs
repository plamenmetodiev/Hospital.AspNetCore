namespace Hospital.Services.Models.MedicineServiceModels
{
    using Data.Models;
    using System.Collections.Generic;

    public class DisplaySuppliersSurviceModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}
