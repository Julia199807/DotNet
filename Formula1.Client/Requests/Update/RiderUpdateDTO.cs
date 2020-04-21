using Formula1.Client.Requests.Create;

namespace Formula1.Client.Requests.Update
{
    public class RiderUpdateDTO : RiderCreateDTO
    {
        public int Id { get; set; }
    }
}