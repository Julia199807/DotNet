using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.DataAccess.Context;
using Formula1.DataAccess.Contracts;
using Formula1.Domain;
using Formula1.Domain.Contracts;
using Formula1.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace Formula1.DataAccess.Implementations
{
    public class RiderDataAccess : IRiderDataAccess
    {
        private F1TeamContext Context { get; }
        private IMapper Mapper { get; }

        public RiderDataAccess(F1TeamContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Rider> InsertAsync(RiderUpdateModel rider)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Rider>(rider));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Rider>(result.Entity);
        }

        public async Task<IEnumerable<Rider>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Rider>>(await this.Context.Rider.Include(x => x.F1Team).ToListAsync());
        }

        public async Task<Rider> GetAsync(IRiderIdentity riderId)
        {

            var result = await this.Get(riderId);
            return this.Mapper.Map<Rider>(result);
        }
        
        private async Task<Formula1.DataAccess.Entities.Rider> Get(IRiderIdentity riderId)
        {
            if (riderId == null)
                throw new ArgumentNullException(nameof(riderId));
            return await this.Context.Rider.Include(x => x.F1Team).FirstOrDefaultAsync(x => x.Id == riderId.Id);
            
        }

        public async Task<Rider> UpdateAsync(RiderUpdateModel rider)
        {
            var existing = await this.Get(rider);

            var result = this.Mapper.Map(rider, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Rider>(result);
        }

        public async Task<Rider> GetByAsync(IRiderContainer rider)
        {
            return rider.RiderId.HasValue 
                ? this.Mapper.Map<Rider>(await this.Context.Rider.FirstOrDefaultAsync(x => x.Id == rider.RiderId)) 
                : null;
        }
    }
}