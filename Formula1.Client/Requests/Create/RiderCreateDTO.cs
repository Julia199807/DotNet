using System.ComponentModel.DataAnnotations;

namespace Formula1.Client.Requests.Create
{
    public class RiderCreateDTO
    {

        //Имя гощника
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        //Национальность
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        
        //Сезоны
        [Required(ErrorMessage = "Seasons is required")]
        public int Seasons { get; set; }
        
        //Чемпион мира
        [Required(ErrorMessage = "Champion is required")]
        public int Champion { get; set; }
        
        //Гран-при(старты)
        [Required(ErrorMessage = "Starts is required")]
        public int Starts { get; set; }
        
        //Победы
        [Required(ErrorMessage = "Wins is required")]
        public int Wins { get; set; }

        //Поулы
        [Required(ErrorMessage = "Poles is required")]
        public int Poles { get; set; }

        public int? F1TeamId { get; set; }
    }
}