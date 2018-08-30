namespace Hospital.Services.Models.PatientServiceModels
{
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;

    public class RegisterPatientDiagnosesMedcinesServiceModel : IMapFrom<Diagnosis>
    {
        public IEnumerable<Diagnosis> Diagnoses { get; set; }

        public IEnumerable<Medicine> Medicines { get; set; }
    }
}
