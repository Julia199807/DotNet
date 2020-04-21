using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1.DataAccess.Entities
{
    public class Rider
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
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

        public virtual F1Team F1Team { get; set; }
    }
}