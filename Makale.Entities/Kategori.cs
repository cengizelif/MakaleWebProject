using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale.Entities
{
    public class Kategori:EntityBase
    {       
        public string Baslik { get; set; }
        public string Aciklama { get; set; }

        public virtual List<Makale> Makaleler { get; set; }
    }
}
