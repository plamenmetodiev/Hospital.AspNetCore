namespace Hospital.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.SupplierServiceModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SupplierService : ISupplierService
    {
        private readonly HospitalDbContext db;
        private readonly IMapper mapper;

        public SupplierService(HospitalDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task AddAsync(string name, bool isImporter)
        {
            var supplier = new Supplier
            {
                Name = name,
                IsImporter = isImporter
            };

            this.db.Add(supplier);

            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<SupplierServiceModel>> AllSuppliersAsync()
            => await this.db
            .Suppliers
            .OrderBy(s => s.Name)
            .ProjectTo<SupplierServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

        public async Task DeleteAsync(int id)
        {
            var supplier = await this.db.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

            this.db.Remove(supplier);

            await this.db.SaveChangesAsync();
        }

        public async Task<SupplierServiceModel> DisplaySupplierAsync(int id)
            => await this.db
            .Suppliers
            .Where(s => s.Id == id)
            .ProjectTo<SupplierServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        public async Task EditSupplierAsync(int id, string name)
        {
            var supplier = await this.db.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

            supplier.Name = name;

            db.Update(supplier);

            await db.SaveChangesAsync();
        }
    }
}
