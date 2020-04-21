using Formula1.Domain.Contracts;

namespace Formula1.Domain.Models
{
    public class RiderUpdateModel : IRiderIdentity, IF1TeamContainer
    {
        //Идентификатор
        public int Id { get; set; }
        
        //Имя гощника
        public string Name { get; set; }
        
        //Национальность
        public string Country { get; set; }
        
        //Сезоны
        public int Seasons { get; set; }
        
        //Чемпион мира
        public int Champion { get; set; }
        
        //Гран-при(старты)
        public int Starts { get; set; }
        
        //Победы
        public int Wins { get; set; }

        //Поулы
        public int Poles { get; set; }
        
        public int? F1TeamId { get; set; }
    }
}