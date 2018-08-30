namespace Hospital.Services.Models.PatientServiceModels
{
    using AutoMapper;
    using Hospital.Common.Mapping;
    using Hospital.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CurrentlyRegisteredPatientServiceModel : IMapFrom<Patient>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Diagnosis { get; set; }

        public DateTime RegistrationDate { get; set; }

        public IEnumerable<string> Medicines{ get;set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Patient, CurrentlyRegisteredPatientServiceModel>()
                .ForMember(r => r.Diagnosis, cfg => cfg.MapFrom(p =>
                p.Diagnosis.Name))
                .ForMember(p => p.Medicines, cfg => cfg
                .MapFrom(m => m.Medicines.Select(y => y.Medicine.Name ).ToList()));
        }
    }
}
