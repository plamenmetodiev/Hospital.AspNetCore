namespace Hospital.Services.Models.PatientServiceModels
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PatientDetailsServiceModel : IMapFrom<Patient>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public bool HasHealthInsurance { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? DeregistrationDate { get; set; }

        public string Doctor { get; set; }

        public string Diagnosis { get; set; }

        public double TotalCost { get; set; }

        public IEnumerable<string> Medicines { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Patient, PatientDetailsServiceModel>()
                .ForMember(p => p.Doctor, cfg => cfg.MapFrom(p => $"{p.Doctor.FirstName} {p.Doctor.LastName}"))
                .ForMember(p => p.Diagnosis, cfg => cfg.MapFrom(p => p.Diagnosis.Name))
                .ForMember(p => p.Medicines, cfg => cfg
                    .MapFrom(m => m.Medicines.Select(y => y.Medicine.Name).ToList()))
                .ForMember(p => p.TotalCost, cfg => cfg
                    .MapFrom(m => m.Medicines.Select(y => y.Medicine.Price).Sum()));
        }
    }
}
