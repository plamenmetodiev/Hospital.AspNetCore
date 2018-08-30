namespace Hospital.Services
{
    using Models.MedicineServiceModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMedicineService : IService
    {
        Task<IEnumerable<MedicineServiceModel>> DisplayAllMedicinesAsync();
        Task<DisplaySuppliersSurviceModel> DisplayAddMedicineAsync();
        Task AddAsync(string name, double price, int supplierId);
        Task<MedicineDeliveryServiceModel> DisplayDeliveryMedicineAsync(int id);
        Task AddQuantityAsync(int id, int quantity);
        Task<EditMedicineServiceModel> DisplayEditMedicineAsync(int id);
        Task EditMedicineAsync(int id, string name, double price, int supplierId);
        Task<MedicineServiceModel> DisplayDeleteMedicineAsync(int id);
        Task DeleteAsync(int id);
    }
}
