namespace Hospital.Services.Models.MedicineServiceModels
{
    using Data.Models;
    using Common.Mapping;
    using System.Collections.Generic;

    public class EditMedicineServiceModel : IMapFrom<Medicine>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int SupplierId { get; set; }

        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}
