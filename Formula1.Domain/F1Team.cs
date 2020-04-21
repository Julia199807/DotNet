namespace Formula1.Domain
{
    //Информация о команде
    public class F1Team
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