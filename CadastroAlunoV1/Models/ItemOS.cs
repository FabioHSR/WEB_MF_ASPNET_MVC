using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBMF.Models
{
    public class ItemOS
    {
        public int OsId { get; set; }
        public string Espessura { get; set; }
        public string Tecnologia { get; set; }
        public string Adesivado { get; set; }
        public int Qtd { get; set; }
        public int PerdasF { get; set; }
        public int PerdasC { get; set; }
        public int Sobras { get; set; }

        public bool Equals(ItemOS item)
        {
            return (
                this.Espessura == item.Espessura &&
                this.Tecnologia == item.Tecnologia &&
                this.Adesivado == item.Adesivado
                );
        }
    }
}
