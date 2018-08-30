namespace Hospital.Services.Models.MedicineServiceModels
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class MedicineDeliveryServiceModel : IMapFrom<Medicine>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Supplier { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Medicine, MedicineServiceModel>()
                .ForMember(s => s.SupplierName, cfg => cfg.MapFrom(m => m.Supplier.Name));
        }
    }
}
