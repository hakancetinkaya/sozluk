﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context con = new Context();
        DbSet<Category> _dbSet;
        public void Delete(Category p)
        {
            _dbSet.Remove(p);
            con.SaveChanges();
        }

        public void  Insert(Category p)
        {
            _dbSet.Add(p);
            con.SaveChanges();
        }

        public List<Category> List()
        {

            return _dbSet.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            con.SaveChanges();
        }
    }
}