namespace Hospital.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Services.Models.MedicineServiceModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MedicineService : IMedicineService
    {
        private readonly HospitalDbContext db;
        private readonly IMapper mapper;

        public MedicineService(HospitalDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<DisplaySuppliersSurviceModel> DisplayAddMedicineAsync()
        {
            var suppliers = await db.Suppliers.ToListAsync();
            return new DisplaySuppliersSurviceModel
            {
                Suppliers = suppliers
            };
        }

        public async Task AddAsync(string name, double price, int supplierId)
        {
            var medicine = new Medicine
            {
                Name = name,
                Price = price,
                SupplierId = supplierId,
                Quantity = 0
            };

            await this.db.AddAsync(medicine);

            await this.db.SaveChangesAsync();
        }

        public async Task AddQuantityAsync(int id, int quantity)
        {
            var medicine = await this.db
                .Medicines
                .FirstOrDefaultAsync(m => m.Id == id);

            medicine.Quantity += quantity;

            this.db.Update(medicine);

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medicine = await this.db
                .Medicines
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medicine.Quantity == 0)
            {
                this.db.Remove(medicine);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MedicineServiceModel>> DisplayAllMedicinesAsync()
            => await this.db
                .Medicines
                .OrderBy(m => m.Name)
                .ProjectTo<MedicineServiceModel>(mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<MedicineDeliveryServiceModel> DisplayDeliveryMedicineAsync(int id)
            => await this.db
                .Medicines
                .Where(m => m.Id == id)
                .ProjectTo<MedicineDeliveryServiceModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        public async Task<EditMedicineServiceModel> DisplayEditMedicineAsync(int id)
        {
            var suppliers = await this.db.Suppliers.ToListAsync();

            var medicine = await this.db
            .Medicines
            .Where(m => m.Id == id)
            .ProjectTo<EditMedicineServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

            medicine.Suppliers = suppliers;

            return medicine;
        }

        public async Task<MedicineServiceModel> DisplayDeleteMedicineAsync(int id)
            => await this.db
                .Medicines
                .Where(m => m.Id == id)
                .ProjectTo<MedicineServiceModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        public async Task EditMedicineAsync(int id, string name, double price, int supplierId)
        {
            var medicine = await this.db
                .Medicines
                .FirstOrDefaultAsync(m => m.Id == id);

            medicine.Name = name;
            medicine.Price = price;
            medicine.SupplierId = supplierId;

            this.db.Update(medicine);

            await this.db.SaveChangesAsync();
        }
    }
}
