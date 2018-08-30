namespace Hospital.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Threading.Tasks;
    using Web.Models.Diagnoses;

    using static WebConstants;

    //[Authorize(Roles = ProfessorRole)]
    public class DiagnosesController : Controller
    {
        private readonly IDiagnosisService diagnoses;

        public DiagnosesController(IDiagnosisService diagnoses)
        {
            this.diagnoses = diagnoses;
        }

        [Authorize(Roles = "Professor,Doctor")]
        public async Task<IActionResult> Index()
            => View(await diagnoses.DisplayAllDiagnoses());

        [Authorize(Roles = ProfessorRole)]
        public IActionResult Add()
            => View(new DiagnosisFormModel());

        [Authorize(Roles = ProfessorRole)]
        [HttpPost]
        public async Task<IActionResult> Add(DiagnosisFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await diagnoses.AddAsync(model.Name, model.Description);

            return RedirectToAction(
                nameof(DiagnosesController.Index),
                "Diagnoses",
                new { area = string.Empty });
        }

        [Authorize(Roles = ProfessorRole)]
        public async Task<IActionResult> Edit(int id)
        {
            var diagnosis = await diagnoses.DisplayDiagnosisAsync(id);
            return View(new DiagnosisFormModel
            {
                Name = diagnosis.Name,
                Description = diagnosis.Description
            });
        }

        [Authorize(Roles = ProfessorRole)]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, DiagnosisFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.diagnoses.EditAsync(id,
                model.Name,
                model.Description);

            return RedirectToAction(
                nameof(DiagnosesController.Index),
                "Diagnoses",
                new { area = string.Empty });
        }

        [Authorize(Roles = ProfessorRole)]
        public async Task<IActionResult> Delete(int id)
         =>View(await diagnoses.DisplayDiagnosisAsync(id));

        [Authorize(Roles = ProfessorRole)]
        [HttpPost]
        public async Task<IActionResult> Confirm(int id)
        {
            await this.diagnoses.DeleteAsync(id);

            return RedirectToAction(
                nameof(DiagnosesController.Index),
                "Diagnoses",
                new { area = string.Empty });
        }

    }
}