namespace Hospital.Services.Models.MedicineServiceModels
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class MedicineServiceModel : IMapFrom<Medicine>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string SupplierName { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Medicine, MedicineServiceModel>()
                .ForMember(s => s.SupplierName, cfg => cfg
                .MapFrom(m => m.Supplier.Name));
        }
    }
}
