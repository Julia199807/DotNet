using Formula1.Domain.Contracts;

namespace Formula1.Domain.Models
{
    public class F1TeamUpdateModel : IF1TeamIdentity
    {
        //Идентификатор
        public int Id { get; set; }
        
        //Название команды
        public string TeamName { get; set; }
        
        //Имя руководителя команды
        public string LeaderName { get; set; } 
        
        //Страна команды
        public string TeamCountry { get; set; }
    }
}