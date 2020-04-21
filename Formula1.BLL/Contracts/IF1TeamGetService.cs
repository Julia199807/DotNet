using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.Domain;
using Formula1.Domain.Contracts;

namespace Formula1.BLL.Contracts
{
    public interface IF1TeamGetService
    {
        Task<IEnumerable<F1Team>> GetAsync();
        Task<F1Team> GetAsync(IF1TeamIdentity f1Team);
        Task ValidateAsync(IF1TeamContainer departmentContainer);
    }
}