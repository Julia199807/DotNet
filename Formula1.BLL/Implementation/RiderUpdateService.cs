using System.Threading.Tasks;
using Formula1.BLL.Contracts;
using Formula1.DataAccess.Contracts;
using Formula1.Domain;
using Formula1.Domain.Models;

namespace Formula1.BLL.Implementation
{
    public class RiderUpdateService : IRiderUpdateService
    {
        private IRiderDataAccess RiderDataAccess { get; }
        private IF1TeamGetService F1TeamGetService { get; }

        public RiderUpdateService(IRiderDataAccess riderDataAccess, IF1TeamGetService f1TeamGetService)
        {
            RiderDataAccess = riderDataAccess;
            F1TeamGetService = f1TeamGetService;
        }

        public async Task<Rider> UpdateAsync(RiderUpdateModel rider)
        {
            await F1TeamGetService.ValidateAsync(rider);

            return await RiderDataAccess.UpdateAsync(rider);

        }
    }
}