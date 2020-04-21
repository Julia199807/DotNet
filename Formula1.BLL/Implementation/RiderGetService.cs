using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.BLL.Contracts;
using Formula1.DataAccess.Contracts;
using Formula1.Domain;
using Formula1.Domain.Contracts;

namespace Formula1.BLL.Implementation
{
    public class RiderGetService : IRiderGetService
    {
        private IRiderDataAccess RiderDataAccess { get; }
        
        public RiderGetService(IRiderDataAccess f1TeamDataAccess)
        {
            this.RiderDataAccess = f1TeamDataAccess;
        }
        public Task<IEnumerable<Rider>> GetAsync()
        {
            return this.RiderDataAccess.GetAsync();
        }

        public Task<Rider> GetAsync(IRiderIdentity rider)
        {
            return this.RiderDataAccess.GetAsync(rider);
        }

        public async Task ValidateAsync(IRiderContainer riderContainer)
        {
            if (riderContainer == null)
            {
                throw new ArgumentNullException(nameof(riderContainer));
            }
            
            var rider = await this.GetBy(riderContainer);

            if (riderContainer.RiderId.HasValue && rider == null)
            {
                throw new InvalidOperationException($"Rider not found by id {riderContainer.RiderId}");
            }
        }
        private Task<Rider> GetBy(IRiderContainer departmentContainer)
        {
            return this.RiderDataAccess.GetByAsync(departmentContainer);
        }
    }
}