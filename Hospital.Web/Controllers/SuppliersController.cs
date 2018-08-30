namespace Hospital.Web.Controllers
{
    using Hospital.Web.Models.Suppliers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Threading.Tasks;
    using static WebConstants;

    [Authorize(Roles = ManagerRole)]
    public class SuppliersController : Controller
    {
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        public async Task<IActionResult> Index()
            => View(await suppliers.AllSuppliersAsync());

        public IActionResult Add()
            => View(new SupplierFormModel());

        [HttpPost]
        public async Task<IActionResult> Add(SupplierFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.suppliers.AddAsync(model.Name, model.IsImporter);

            return RedirectToAction(
                nameof(SuppliersController.Index),
                "Suppliers",
                new { area = string.Empty });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await suppliers.DisplaySupplierAsync(id);
            return View(new SupplierFormModel
            {
                Name = supplier.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SupplierFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await suppliers.EditSupplierAsync(id, model.Name);

            return RedirectToAction(
                nameof(SuppliersController.Index),
                "Suppliers",
                new { area = string.Empty });
        }
        public async Task<IActionResult> Delete(int id)
            => View(await suppliers.DisplaySupplierAsync(id));

        [HttpPost]
        public async Task<IActionResult> Confirm(int id)
        {
            await this.suppliers.DeleteAsync(id);

            return RedirectToAction(
                nameof(SuppliersController.Index),
                "Suppliers",
                new { area = string.Empty });

        }
    }
}