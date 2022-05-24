using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale.Entities
{
    public class Kullanici:EntityBase
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public bool Admin { get; set; }
        public bool Aktif { get; set; }
        public Guid AktifGuid { get; set; }

        public virtual List<Makale> Makaleler { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }

    }
}
