namespace Hospital.Services
{
    using Models.DiagnosisServiceModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDiagnosisService : IService
    {
        Task<IEnumerable<DiagnosisServiceModel>> DisplayAllDiagnoses();

        Task<DiagnosisServiceModel> DisplayDiagnosisAsync(int diagnosisId);
        Task EditAsync(int id, string name, string description);
        Task AddAsync(string name, string description);
        Task DeleteAsync(int id);
    }
}
