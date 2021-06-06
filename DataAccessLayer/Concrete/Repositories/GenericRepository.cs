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
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = con.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = con.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            con.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addedEtitiy = con.Entry(p);
            addedEtitiy.State = EntityState.Added;
           // _object.Add(p);
            con.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntitiy = con.Entry(p);
            updatedEntitiy.State = EntityState.Modified;
            con.SaveChanges();
        }
    }
}
