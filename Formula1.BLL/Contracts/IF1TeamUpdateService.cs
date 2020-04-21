using System.Threading.Tasks;
using Formula1.Domain;
using Formula1.Domain.Models;

namespace Formula1.BLL.Contracts
{
    public interface IF1TeamUpdateService
    {
        Task<F1Team> UpdateAsync(F1TeamUpdateModel f1Team);
    }
}