using Formula1.Domain.Contracts;

namespace Formula1.Domain
{
    //Информация о гонщике
    public class Rider : IF1TeamContainer
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

        public F1Team F1Team { get; set; }
        
        public int? F1TeamId => F1Team.Id;

        
    }
}