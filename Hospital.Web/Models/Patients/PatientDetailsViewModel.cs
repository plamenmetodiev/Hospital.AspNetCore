namespace Hospital.Web.Models.Patients
{
    using Services.Models.PatientServiceModels;

    public class PatientDetailsViewModel
    {
        public PatientDetailsServiceModel Patient { get; set; }

        public int Age { get; set; }

        public bool IsPatientCurrentlyRegistered { get; set; }
    }
}
