using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.Domain;
using Formula1.Domain.Contracts;
using Formula1.Domain.Models;
namespace Formula1.DataAccess.Contracts
{
    public interface IRiderDataAccess
    {
        Task<Rider> InsertAsync(RiderUpdateModel rider);
        Task<IEnumerable<Rider>> GetAsync();
        Task<Rider> GetAsync(IRiderIdentity riderId);
        Task<Rider> UpdateAsync(RiderUpdateModel rider);
        Task<Rider> GetByAsync(IRiderContainer rider);

    }
}