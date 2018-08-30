namespace Hospital.Services.Models.PatientServiceModels
{
    using Common.Mapping;
    using Data.Models;
    using System;

    public class EditPatientServiceModel : IMapFrom<Patient>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public bool HasHealthInsurance { get; set; }
    }
}
