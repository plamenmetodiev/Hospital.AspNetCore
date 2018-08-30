namespace Hospital.Services.Admin.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Hospital.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminUserService : IAdminUserService
    {
        private readonly HospitalDbContext db;
        private readonly IMapper mapper;

        public AdminUserService(HospitalDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
             => this.mapper.Map<IEnumerable<AdminUserListingServiceModel>>(await this.db.Users.ToListAsync());
    }
}
