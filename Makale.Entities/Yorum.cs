using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale.Entities
{
    public class Yorum:EntityBase
    {
        public string YorumText { get; set; }

        public virtual Makale Makale { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
