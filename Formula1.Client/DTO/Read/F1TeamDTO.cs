namespace Formula1.Client.DTO.Read
{
    public class F1TeamDTO
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