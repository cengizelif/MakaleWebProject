using Makale.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Makale.DataAccessLayer
{
   public class Repository<T> where T:class
    {
        DatabaseContext db = new DatabaseContext();

        private DbSet<T> objset;

        public Repository()
        {
            objset = db.Set<T>();
        }

        public List<T> List()
        {
            return objset.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> where )
        {
          return  objset.Where(where).ToList();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return objset.FirstOrDefault(where);
        }


        public int Insert(T nesne)
        {
            objset.Add(nesne);
            return Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update()
        {
            return Save();
        }

        public int Delete(T nesne)
        {
            objset.Remove(nesne);
            return Save();
        }

    }
}
