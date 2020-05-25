using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeledocTask.Models
{
    public enum EntType
    {
        [Display(Name = "Юр. лицо")]
        UL,
        [Display(Name = "ИП")]
        IP,
        [Display(Name = "Учредитель")]
        UCHR
    }

    public class Entity
    {
        public int ID { get; set; }
        [DisplayName("Наименование")]
        public string Title { get; set; }
        [DisplayName("ИНН")]
        public long INN { get; set; }
        [DisplayName("Дата создания")]
        public DateTime CrDate { get; set; }
        [DisplayName("Дата обновления")]
        public DateTime ChDate { get; set; }
        [DisplayName("Тип")]
        public EntType EntType { get; set; }
        public Entity ParentEntity { get; set; }
    }
}
