using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TeledocTask.Models
{
    public class UCHCreationModel
    {
        [DisplayName("Ф.И.О.")]
        public string Title { get; set; }
        [DisplayName("ИНН")]
        public long INN { get; set; }
        public EntType EntType { get; set; }
        [DisplayName("Привязка к юр. лицу")]
        public int ParentEntity { get; set; }
    }
}
