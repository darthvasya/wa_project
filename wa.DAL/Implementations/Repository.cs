using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using wa.DAL.Contracts;
using System.Data.Entity;
using System.Linq.Expressions;

namespace wa.DAL.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private sysengEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbSet = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected sysengEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(string Id)
        {
            return dbSet.Find(Id);
        }

        public virtual T GetById(long Id)
        {
            return dbSet.Find(Id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
