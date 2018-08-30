namespace Hospital.Services.Models.PatientServiceModels
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class AddMedicinesToPatientServiceModel : IMapFrom<Patient>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Diagnosis { get; set; }

        public IEnumerable<Medicine> Medicines { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Patient, AddMedicinesToPatientServiceModel>()
            .ForMember(a => a.Medicines, cfg => cfg
                .MapFrom(m => m.Medicines.Select(y => y.Medicine).ToList()))
            .ForMember(a => a.Diagnosis, cfg => cfg
                .MapFrom(p => p.Diagnosis.Name))
            .ForMember(a => a.Name, cfg => cfg
                .MapFrom(p => $"{p.FirstName} {p.LastName}"));
        }
    }
}
