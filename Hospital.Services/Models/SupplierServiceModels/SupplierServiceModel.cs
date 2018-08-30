namespace Hospital.Services.Models.SupplierServiceModels
{
    using Common.Mapping;
    using Data.Models;

    public class SupplierServiceModel : IMapFrom<Supplier>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsImporter { get; set; }
    }
}
