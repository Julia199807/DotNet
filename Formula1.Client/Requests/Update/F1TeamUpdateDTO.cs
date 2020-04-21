using Formula1.Client.Requests.Create;

namespace Formula1.Client.Requests.Update
{
    public class F1TeamUpdateDTO : F1TeamCreateDTO
    {
        public int Id { get; set; }
    }
}