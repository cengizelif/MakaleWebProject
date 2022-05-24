using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime DegistirmeTarihi { get; set; }
        public string DegistirenKullanici { get; set; }
    }
}
