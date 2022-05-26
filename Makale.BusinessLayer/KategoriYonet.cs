using Makale.DataAccessLayer;
using Makale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale.BusinessLayer
{
    public class KategoriYonet
    {
        private Repository<Kategori> repo_kat = new Repository<Kategori>();
        public List<Kategori> KategoriGetir()
        {
            return repo_kat.List();
        }

        public Kategori KategoriBul(int id)
        {
            return repo_kat.Find(x => x.Id == id);
        }
    }
}
