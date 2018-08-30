namespace Hospital.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.Models.Medicines;

    using static WebConstants;
    
    [Authorize(Roles = ManagerRole)]
    public class MedicinesController : Controller
    {
        private readonly IMedicineService medicines;

        public MedicinesController(IMedicineService medicines)
        {
            this.medicines = medicines;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
            => View(await this.medicines.DisplayAllMedicinesAsync());

        public async Task<IActionResult> Add()
        {
            var suppliers = await this.medicines.DisplayAddMedicineAsync();

            return View(new MedicineFormModel
            {
                Suppliers = suppliers.Suppliers.Select(s => new SelectListItem()
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(MedicineFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.medicines.AddAsync(model.Name, model.Price, model.SupplierId);

            return RedirectToAction(
                nameof(MedicinesController.Index),
                "Medicines",
                new { area = string.Empty });
        }

        public async Task<IActionResult> Deliver(int id)
        {
            var medicine = await this.medicines.DisplayDeliveryMedicineAsync(id);

            return View(new MedicineDeliveryViewModel
            {
                Name = medicine.Name,
                Supplier = medicine.Supplier
            });
        }

        [HttpPost]
        public async Task<IActionResult> Deliver(int id, MedicineDeliverFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           await this.medicines.AddQuantityAsync(id, model.Quantity);

            return RedirectToAction(
                nameof(MedicinesController.Index),
                "Medicines",
                new { area = string.Empty });

        }

        public async Task<IActionResult> Edit(int id)
        {
            var medicine = await this.medicines.DisplayEditMedicineAsync(id);

            return View(new MedicineFormModel
            {
                Name = medicine.Name,
                Price = medicine.Price,
                SupplierId = medicine.SupplierId,
                Suppliers = medicine.Suppliers.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MedicineFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.medicines.EditMedicineAsync(id, model.Name, model.Price, model.SupplierId);

            return RedirectToAction(
                nameof(MedicinesController.Index),
                "Medicines",
                new { area = string.Empty });
        }

        public async Task<IActionResult> Delete(int id)
            => View(await medicines.DisplayDeleteMedicineAsync(id));

        [HttpPost]
        public async Task<IActionResult> Confirm(int id)
        {
            await this.medicines.DeleteAsync(id);

            return RedirectToAction(
                nameof(MedicinesController.Index),
                "Medicines",
                new { area = string.Empty });
        }
    }
}