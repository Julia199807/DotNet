using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1.DataAccess.Entities
{
    public partial class F1Team
    {
        public F1Team()
        {
            this.Rider = new HashSet<Rider>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Rider> Rider { get; set; }

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