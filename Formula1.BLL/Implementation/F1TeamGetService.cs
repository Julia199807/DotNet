using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.BLL.Contracts;
using Formula1.DataAccess.Contracts;
using Formula1.Domain;
using Formula1.Domain.Contracts;

namespace Formula1.BLL.Implementation
{
    
    public class F1TeamGetService : IF1TeamGetService
    {
        private IF1TeamDataAccess F1TeamDataAccess { get; }
        
        public F1TeamGetService(IF1TeamDataAccess f1TeamDataAccess)
        {
            this.F1TeamDataAccess = f1TeamDataAccess;
        }
        public Task<IEnumerable<F1Team>> GetAsync()
        {
            return this.F1TeamDataAccess.GetAsync();
        }

        public Task<F1Team> GetAsync(IF1TeamIdentity f1Team)
        {
            return this.F1TeamDataAccess.GetAsync(f1Team);
        }

        public async Task ValidateAsync(IF1TeamContainer f1TeamContainer)
        {
            if (f1TeamContainer == null)
            {
                throw new ArgumentNullException(nameof(f1TeamContainer));
            }
            
            var f1Team = await this.GetBy(f1TeamContainer);

            if (f1TeamContainer.F1TeamId.HasValue && f1Team == null)
            {
                throw new InvalidOperationException($"F1Team not found by id {f1TeamContainer.F1TeamId}");
            }
        }
        private Task<F1Team> GetBy(IF1TeamContainer f1TeamContainer)
        {
            return this.F1TeamDataAccess.GetByAsync(f1TeamContainer);
        }
    }
}