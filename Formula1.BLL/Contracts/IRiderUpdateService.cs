using System.Threading.Tasks;
using Formula1.Domain;
using Formula1.Domain.Models;

namespace Formula1.BLL.Contracts
{
    public interface IRiderUpdateService
    {
        Task<Rider> UpdateAsync(RiderUpdateModel rider);
    }
}