using CarManager.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext dbContext;

        private IDbSet<T> dbSet;

        //缓存dbSet
        protected virtual IDbSet<T> DbSet {
            get {
                this.dbSet = this.dbSet ?? dbContext.Set<T>();
                return this.dbSet;
            }
       }

        public EfRepository(IDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            if (entity==null)
            {
                throw new NotImplementedException();
            }
            this.DbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }

        public T GetById(object id)
        { 
          return  this.DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity==null)
            {
                throw new NotImplementedException();
            }
            this.DbSet.Add(entity);
            this.dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            this.dbContext.SaveChanges();
        }

      public  IQueryable<T> Table {
            get {
                return this.DbSet;
            }
        }

       
    }

}
