namespace Hospital.Services.Models.PatientServiceModels
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;

    public class DeregisteredPatientServiceModel : IMapFrom<Patient>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Diagnosis { get; set; }

        public DateTime DeregistrationDate { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Patient, DeregisteredPatientServiceModel>()
                .ForMember(r => r.Diagnosis, cfg => cfg.MapFrom(p =>
                p.Diagnosis.Name));
        }
    }
}
