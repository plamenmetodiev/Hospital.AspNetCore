namespace Hospital.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.PatientServiceModels;

    public interface IPatientService : IService
    {
        Task AddMedicinesToPatientAsync(int patientId, int[] medicinesIds);

        Task DeregisterAsync(int patientId);

        Task EditAsync(
            int patientId,
            string firstName,
            string lastName,
            DateTime birthDate,
            string address,
            bool hasHealthInsurance);

        Task RegisterAsync(
            string firstName,
            string lastName,
            DateTime birthDate,
            string address,
            bool hasHealthInsurance,
            DateTime registerDate,
            string doctorId,
            int[] medicinesIds,
            int diagnosisId);

        Task<PatientDetailsServiceModel> FindPatientMedicalProfileAsync(string searchBox);

        Task<IEnumerable<DeregisteredPatientServiceModel>> DisplayDeregisteredPatientsAsync(string userId);

        Task<RegisterPatientDiagnosesMedcinesServiceModel> DisplayDiagnosesMedicinesAsync();

        Task<EditPatientServiceModel> DisplayEditPatientAsync(int patientId);

        Task<PatientDetailsServiceModel> DisplayPatientDetailsAsync(int patientId);

        Task<IEnumerable<CurrentlyRegisteredPatientServiceModel>> DisplayRegisteredPatientsAsync(string userId);

        Task<AddMedicinesToPatientServiceModel> DisplayAddMedicinesAsync(int id);
    }
}
