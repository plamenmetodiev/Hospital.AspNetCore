namespace Hospital.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.PatientServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class PatientService : IPatientService
    {
        private readonly HospitalDbContext db;
        private readonly IMapper mapper;

        public PatientService(HospitalDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DeregisteredPatientServiceModel>> DisplayDeregisteredPatientsAsync(string userId)
            => await this.db.Patients
                .Where(p => p.DoctorId == userId && p.DeregistrationDate != null)
                .OrderByDescending(p => p.DeregistrationDate)
                .ProjectTo<DeregisteredPatientServiceModel>(mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<RegisterPatientDiagnosesMedcinesServiceModel> DisplayDiagnosesMedicinesAsync()
        {
            var medicines = await db.Medicines.Where(m => m.Quantity > 0).ToListAsync();
            var diagnoses = await db.Diagnoses.ToListAsync();
            return new RegisterPatientDiagnosesMedcinesServiceModel
            {
                Diagnoses = diagnoses,
                Medicines = medicines
            };
        }

        public async Task<EditPatientServiceModel> DisplayEditPatientAsync(int patientId)
            => await this.db
                .Patients
                .Where(p => p.Id == patientId)
                .ProjectTo<EditPatientServiceModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        public async Task<PatientDetailsServiceModel> DisplayPatientDetailsAsync(int patientId)
        {
            var model = await this.db
                .Patients
                .Where(p => p.Id == patientId)
                .ProjectTo<PatientDetailsServiceModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (model.HasHealthInsurance)
            {
                model.TotalCost *= 0.7;
            }

            return model;
        }

        public async Task<IEnumerable<CurrentlyRegisteredPatientServiceModel>> DisplayRegisteredPatientsAsync(string userId)
            => await this.db.Patients
                .Where(p => p.DoctorId == userId && p.DeregistrationDate == null)
                .OrderByDescending(p => p.RegistrationDate)
                .ProjectTo<CurrentlyRegisteredPatientServiceModel>(mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task EditAsync(
            int patientId,
            string firstName,
            string lastName,
            DateTime birthDate,
            string address,
            bool hasHealthInsurance)
        {
            var patient = await db
                .Patients
                .FirstOrDefaultAsync(p => p.Id == patientId);
            patient.FirstName = firstName;
            patient.LastName = lastName;
            patient.BirthDate = birthDate;
            patient.Address = address;
            patient.HasHealthInsurance = hasHealthInsurance;

            this.db.Update(patient);

            await this.db.SaveChangesAsync();
        }

        public async Task DeregisterAsync(int patientId)
        {
            var patient = await this.db.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
            patient.DeregistrationDate = DateTime.UtcNow;
            this.db.Update(patient);
            await this.db.SaveChangesAsync();
        }

        public async Task RegisterAsync(
            string firstName,
            string lastName,
            DateTime birthDate,
            string address,
            bool hasHealthInsurance,
            DateTime registerDate,
            string doctorId,
            int[] medicinesIds,
            int diagnosisId)
        {
            var patient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Address = address,
                HasHealthInsurance = hasHealthInsurance,
                RegistrationDate = registerDate,
                DoctorId = doctorId,
                DiagnosisId = diagnosisId,
            };

            this.db.Add(patient);

            //this.db.SaveChanges();

            int patientId = patient.Id;

            List<Medicine> medicines = new List<Medicine>();

            List<PatientMedicine> patientMedicines = new List<PatientMedicine>();

            foreach (var mediceneId in medicinesIds)
            {
                var medicine = this.db
                    .Medicines.FirstOrDefault(m => m.Id == mediceneId);

                if (medicine.Quantity < 1)
                    continue;
                //if(medicine.Quantity)

                medicine.Quantity--;

                var patientMedicine = new PatientMedicine
                {
                    MedicineId = mediceneId,
                    PatientId = patientId
                };

                medicines.Add(medicine);

                patientMedicines.Add(patientMedicine);
            }
            await this.db.AddRangeAsync(patientMedicines);

            this.db.UpdateRange(medicines);

            await this.db.SaveChangesAsync();
        }

        public async Task<AddMedicinesToPatientServiceModel> DisplayAddMedicinesAsync(int id)
        {
            var medicines = await this.db.Medicines.Where(m => m.Quantity > 0).ToListAsync();

            var model = await this.db
                .Patients
                .Where(p => p.Id == id)
                .ProjectTo<AddMedicinesToPatientServiceModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            model.Medicines = medicines;

            return model;
        }

        public async Task AddMedicinesToPatientAsync(int patientId, int[] medicinesIds)
        {
            var patientMedicinesList = new List<PatientMedicine>();

            var patientMedicines = await this.db.PatientMedicine.ToListAsync();

            foreach (var medicineId in medicinesIds)
            {
                var medicine = await this.db.Medicines.FirstOrDefaultAsync(m => m.Id == medicineId);
                var patient = await this.db.Patients.FirstOrDefaultAsync(p => p.Id == patientId);

                if (medicine != null && medicine.Quantity > 0)
                {
                    var patientMedicine = new PatientMedicine
                    {
                        PatientId = patientId,
                        MedicineId = medicineId
                    };
                    var registered = medicine.Patients.Where(pm => pm.MedicineId == medicineId && pm.PatientId == patientId).ToList();

                    if (registered.Count > 0)
                        continue;

                    medicine.Quantity--;

                    db.Update(medicine);

                    patientMedicinesList.Add(patientMedicine);
                }
            }
            await this.db.AddRangeAsync(patientMedicinesList);

            await this.db.SaveChangesAsync();
        }

        public async Task<PatientDetailsServiceModel> FindPatientMedicalProfileAsync(string searchBox)
        {
            Expression<Func<Patient, bool>> func = null;

            if (searchBox == null)
                return null;

            if (searchBox.Contains(' '))
            {
                var names = searchBox.Split(' ').Select(n => n.ToLower().Trim()).ToArray();

                if (names.Count() > 2)
                    return null;

                func = p => p.FirstName.ToLower() == names[0]
                            && p.LastName == names[1];
            }
            else
            {
                func = p => p.FirstName.ToLower() == searchBox.ToLower().Trim();
            }

            return await this.db
                    .Patients
                    .Where(func)
                    .ProjectTo<PatientDetailsServiceModel>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();
        }
    }
}
