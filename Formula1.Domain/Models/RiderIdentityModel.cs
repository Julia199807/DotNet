using Formula1.Domain.Contracts;

namespace Formula1.Domain.Models
{
    public class RiderIdentityModel : IRiderIdentity
    {
        public int Id { get; }

        public RiderIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}