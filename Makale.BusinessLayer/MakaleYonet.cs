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
    }
}
