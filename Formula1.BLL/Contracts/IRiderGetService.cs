using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.Domain;
using Formula1.Domain.Contracts;

namespace Formula1.BLL.Contracts
{
    public interface IRiderGetService
    {
        Task<IEnumerable<Rider>> GetAsync();
        Task<Rider> GetAsync(IRiderIdentity rider);
        Task ValidateAsync(IRiderContainer departmentContainer);
    }
}