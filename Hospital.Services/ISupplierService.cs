namespace Hospital.Services
{
    using Models.SupplierServiceModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISupplierService : IService
    {
        Task AddAsync(string name, bool isImporter);
        Task DeleteAsync(int id);
        Task<IEnumerable<SupplierServiceModel>> AllSuppliersAsync();
        Task<SupplierServiceModel> DisplaySupplierAsync(int id);
        Task EditSupplierAsync(int id, string name);
    }
}
