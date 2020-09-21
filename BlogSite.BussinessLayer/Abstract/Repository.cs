﻿using BlogSite.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BussinessLayer.Abstract
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _objectSet;

        private readonly DataContext _dbContext = new DataContext();
        public Repository()
        {
            _objectSet = _dbContext.Set<T>();//7.8:53
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }

        public T GeyById(int Id)
        {
            return _objectSet.Find(Id);
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public int Update(T obj)
        {
            return Save();
        }
    }
}
