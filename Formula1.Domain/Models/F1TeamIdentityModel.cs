using Formula1.Domain.Contracts;

namespace Formula1.Domain.Models
{
    public class F1TeamIdentityModel : IF1TeamIdentity
    {
        public int Id { get; }

        public F1TeamIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}