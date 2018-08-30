namespace Hospital.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.Models.Patients;

    using static WebConstants;

    [Authorize(Roles = DoctorRole)]
    public class PatientsController : Controller
    {
        private readonly IPatientService patients;
        private readonly UserManager<User> userManager;

        public PatientsController(
            IPatientService patients,
            UserManager<User> userManager)
        {
            this.patients = patients;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.userManager.GetUserId(User);
            return View(await this.patients.DisplayRegisteredPatientsAsync(userId));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var patient = await patients.DisplayPatientDetailsAsync(id);

            var isPatientCurrentlyRegistered = patient.DeregistrationDate == null ? true : false;

            var today = DateTime.Today;

            var age = today.Year - patient.BirthDate.Year;
            if (patient.BirthDate > today.AddYears(-age)) age--;

            return View(new PatientDetailsViewModel
            {
                Patient = patient,
                IsPatientCurrentlyRegistered = isPatientCurrentlyRegistered,
                Age = age
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await this.patients.DisplayEditPatientAsync(id);

            return View(new EditPatientFormModel
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Address = patient.Address,
                BirthDate = patient.BirthDate,
                HasHealthInsurance = patient.HasHealthInsurance
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPatientFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.patients.EditAsync(id,
                model.FirstName,
                model.LastName,
                model.BirthDate,
                model.Address,
                model.HasHealthInsurance);

            return RedirectToAction(
                nameof(PatientsController.Index),
                "Patients",
                new { area = string.Empty });
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var medicinesAndDiagnoses = await patients.DisplayDiagnosesMedicinesAsync();
            return View(new RegisterPatientFormModel
            {
                Diagnoses = medicinesAndDiagnoses.Diagnoses.Select(d => 
                new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }),
                Medicines = medicinesAndDiagnoses.Medicines.Select(m =>
                new SelectListItem()
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                })
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterPatientFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = this.userManager.GetUserId(User);

            var registrationDate = DateTime.UtcNow;
            await this.patients.RegisterAsync(
                model.FirstName,
                model.LastName,
                model.BirthDate,
                model.Address,
                model.HasHealthInsurance,
                registrationDate,
                userId,
                model.MedicinesIds,
                model.DiagnosisId);

            return RedirectToAction(
                nameof(PatientsController.Index),
                "Patients",
                new { area = string.Empty });
        }

        [HttpGet]
        public async Task<IActionResult> Deregistered()
        {
            var userId = this.userManager.GetUserId(User);
            return View(await this.patients.DisplayDeregisteredPatientsAsync(userId));
        }

        [HttpPost]
        public async Task<IActionResult> Deregister(int id)
        {
            await patients.DeregisterAsync(id);

            return RedirectToAction(
                nameof(PatientsController.Index),
                "Patients",
                new { area = string.Empty });
        }

        [ActionName("add-medicines")]
        public async Task<IActionResult> AddMedicines(int id)
        {
            var serviceModel = await this.patients
                    .DisplayAddMedicinesAsync(id);
            return View("AddMedicines",new AddMedicinesFormModel
            {
                Name = serviceModel.Name,
                Diagnosis = serviceModel.Diagnosis,
                Medicines = serviceModel.Medicines.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                })
            });
        }

        [HttpPost]
        [ActionName("add-medicines")]
        public async Task<IActionResult> AddMedicine(int id, AddMedicinesFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMedicines", model);
            }

            await this.patients.AddMedicinesToPatientAsync(id, model.MedicinesIds);

            return RedirectToAction(
                nameof(PatientsController.Index),
                "Patients",
                new { area = string.Empty });
        }
    }
}