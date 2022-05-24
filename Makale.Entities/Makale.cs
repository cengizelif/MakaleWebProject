using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale.Entities
{
    public class Makale:EntityBase
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public bool Taslak { get; set; }
        public int BegeniSayisi { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual List<Yorum>  Yorumlar { get; set; }
    }
}
