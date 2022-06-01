using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makale.DataAccessLayer;
using Makale.Entities;

namespace Makale.BusinessLayer
{
    public class MakaleYonet
    {
        private Repository<Not> repo_not = new Repository<Not>();

        public List<Not> MakaleGetir()
        {
            return repo_not.List();
        }

        public Not NotBul(int id)
        {
            return repo_not.Find(x => x.Id == id);
        }

        public void NotKaydet(Not not)
        {
            throw new NotImplementedException();
        }

        public void NotUpdate(Not not)
        {
            throw new NotImplementedException();
        }

        public void NotSil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
