namespace Hospital.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Threading.Tasks;
    using Web.Models;
    using Web.Models.Home;
    using Web.Models.Patients;
    using System;

    public class HomeController : Controller
    {
        private readonly IPatientService patient;

        public HomeController(IPatientService patient)
        {
            this.patient = patient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(SearchPatientFormModel model)
        {
            var patient = await this.patient.FindPatientMedicalProfileAsync(model.SearchBox);

            if (patient != null)
            {
                var today = DateTime.Today;

                var age = today.Year - patient.BirthDate.Year;
                if (patient.BirthDate > today.AddYears(-age)) age--;

                var isPatientCurrentlyRegistered = patient.DeregistrationDate == null ? true : false;

                var viewModel = new PatientDetailsViewModel
                {
                    Patient = patient,
                    IsPatientCurrentlyRegistered = isPatientCurrentlyRegistered,
                    Age = age
                };

                return View(viewModel);
            }
            else return View(new PatientDetailsViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
