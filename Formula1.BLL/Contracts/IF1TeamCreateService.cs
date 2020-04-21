using System.Threading.Tasks;
using Formula1.Domain;
using Formula1.Domain.Models;

namespace Formula1.BLL.Contracts
{
    public interface IF1TeamCreateService
    {
        Task<F1Team> CreateAsync(F1TeamUpdateModel f1Team);
    }
}