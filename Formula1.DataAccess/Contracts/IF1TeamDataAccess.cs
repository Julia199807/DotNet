using System.Collections.Generic;
using System.Threading.Tasks;
using Formula1.Domain;
using Formula1.Domain.Contracts;
using Formula1.Domain.Models;
namespace Formula1.DataAccess.Contracts
{
    public interface IF1TeamDataAccess
    {
        Task<F1Team> InsertAsync(F1TeamUpdateModel f1Team);
        Task<IEnumerable<F1Team>> GetAsync();
        Task<F1Team> GetAsync(IF1TeamIdentity f1TeamId);
        Task<F1Team> UpdateAsync(F1TeamUpdateModel f1Team);
        Task<F1Team> GetByAsync(IF1TeamContainer departmentId);

    }
}