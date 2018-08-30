namespace Hospital.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Services.Models.DiagnosisServiceModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DiagnosisService : IDiagnosisService
    {
        private readonly HospitalDbContext db;
        private readonly IMapper mapper;

        public DiagnosisService(HospitalDbContext db, IMapper mapper)
        {

            this.db = db;
            this.mapper = mapper;
        }

        public async Task AddAsync(string name, string description)
        {
            var diagnosis = new Diagnosis
            {
                Name = name,
                Description = description
            };

            await this.db.AddAsync(diagnosis);

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var diagnosis = await this.db
                .Diagnoses
                .FirstOrDefaultAsync(d => d.Id == id);

            this.db.Remove(diagnosis);

            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<DiagnosisServiceModel>> DisplayAllDiagnoses()
            => await this.db
                .Diagnoses
                .OrderBy(d => d.Name)
                .ProjectTo<DiagnosisServiceModel>(mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<DiagnosisServiceModel> DisplayDiagnosisAsync(int diagnosisId)
            => await this.db
                .Diagnoses
                .Where(d => d.Id == diagnosisId)
                .ProjectTo<DiagnosisServiceModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        public async Task EditAsync(int id, string name, string description)
        {
            var diagnosis = await this.db
                .Diagnoses.FirstOrDefaultAsync(d => d.Id == id);

            diagnosis.Name = name;
            diagnosis.Description = description;

            this.db.Update(diagnosis);

            await this.db.SaveChangesAsync();
        }
    }
}
