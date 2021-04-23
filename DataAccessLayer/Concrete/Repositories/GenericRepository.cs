using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context con = new Context();
        DbSet<T> _dbSet;
        public GenericRepository()
        {
            _dbSet = con.Set<T>();
        }

        public void Delete(T p)
        {
            _dbSet.Remove(p);
            con.SaveChanges();
        }

        public void Insert(T p)
        {
            _dbSet.Add(p);
            con.SaveChanges();
        }

        public List<T> List()
        {
            return _dbSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }

        public void Update(T p)
        {
            con.SaveChanges();
        }
    }
}
