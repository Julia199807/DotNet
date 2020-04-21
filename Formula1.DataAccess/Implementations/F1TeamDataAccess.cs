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
    public class F1TeamDataAccess : IF1TeamDataAccess
    {
        private F1TeamContext Context { get; }
        private IMapper Mapper { get; }

        public F1TeamDataAccess(F1TeamContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<F1Team> InsertAsync(F1TeamUpdateModel f1Team)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.F1Team>(f1Team));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<F1Team>(result.Entity);
        }

        public async Task<IEnumerable<F1Team>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<F1Team>>(
                await this.Context.F1Team.ToListAsync());

        }

        public async Task<F1Team> GetAsync(IF1TeamIdentity f1Team)
        {
            var result = await this.Get(f1Team);

            return this.Mapper.Map<F1Team>(result);
        }

        public async Task<F1Team> UpdateAsync(F1TeamUpdateModel f1Team)
        {
            var existing = await this.Get(f1Team);

            var result = this.Mapper.Map(f1Team, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<F1Team>(result);
        }

        public async Task<F1Team> GetByAsync(IF1TeamContainer f1Team)
        {
            return f1Team.F1TeamId.HasValue 
                ? this.Mapper.Map<F1Team>(await this.Context.F1Team.FirstOrDefaultAsync(x => x.Id == f1Team.F1TeamId)) 
                : null;
        }

        private async Task<Formula1.DataAccess.Entities.F1Team> Get(IF1TeamIdentity f1Team)
        {
            if(f1Team == null)
                throw new ArgumentNullException(nameof(f1Team));
            return await this.Context.F1Team.FirstOrDefaultAsync(x => x.Id == f1Team.Id);
        }
    }
}