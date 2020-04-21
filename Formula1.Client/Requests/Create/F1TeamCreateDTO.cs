using System.ComponentModel.DataAnnotations;

namespace Formula1.Client.Requests.Create
{
    public class F1TeamCreateDTO
    {

        //Название команды
        [Required(ErrorMessage = "TeamName is required")]
        public string TeamName { get; set; }

        //Имя руководителя команды
        [Required(ErrorMessage = "LeaderName is required")]
        public string LeaderName { get; set; }

        //Страна команды
        [Required(ErrorMessage = "TeamCountry is required")]
        public string TeamCountry { get; set; }
    }
}
