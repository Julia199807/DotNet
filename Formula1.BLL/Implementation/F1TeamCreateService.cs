using System.Threading.Tasks;
using Formula1.BLL.Contracts;
using Formula1.DataAccess.Contracts;
using Formula1.Domain;
using Formula1.Domain.Models;

namespace Formula1.BLL.Implementation
{
    public class F1TeamCreateService : IF1TeamCreateService
    {
        private IF1TeamDataAccess F1TeamDataAccess { get; }

        public F1TeamCreateService(IF1TeamDataAccess f1TeamDataAccess)
        {
            F1TeamDataAccess = f1TeamDataAccess;
        }

        public  Task<F1Team> CreateAsync(F1TeamUpdateModel f1Team)
        {
            return F1TeamDataAccess.InsertAsync(f1Team);
        }
    }
}