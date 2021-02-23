using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccesLayer
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly AerolineaEntities Context;

        private readonly DbSet<TEntity> DBSet;


        public Repository(AerolineaEntities context)
        {
            Context = context;
            DBSet = context.Set<TEntity>();

        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderExpression = null)
        {
            return this.GetQuery(predicate, orderExpression).AsEnumerable();
        }

        public virtual IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderExpression = null)
        {
            IQueryable<TEntity> qry = this.DBSet;

            if (predicate != null)
                qry = qry.Where(predicate);

            if (orderExpression != null)
                return orderExpression(qry);


            return qry;
        }

        public virtual void Insert<T>(T entity) where T : class
        {
            DbSet<T> dbSet = this.Context.Set<T>();
            dbSet.Add(entity);
            SaveChanges();
        }

        public virtual void Insert(TEntity entity)
        {
            this.DBSet.Add(entity);
            SaveChanges();
        }

        public virtual void Update<T>(T entity) where T : class
        {
            DbSet<T> dbSet = this.Context.Set<T>();
            dbSet.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(TEntity entity)
        {
            this.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            DbSet<T> dbSet = this.Context.Set<T>();

            if (this.Context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);

        }

        public virtual void Delete(TEntity entity)
        {
            if (this.Context.Entry(entity).State == EntityState.Detached)
                this.Attach(entity);

            this.DBSet.Remove(entity);

        }

        public virtual void Delete<T>(object[] id) where T : class
        {
            DbSet<T> dbSet = this.Context.Set<T>();
            T entity = dbSet.Find(id);
            dbSet.Attach(entity);
            dbSet.Remove(entity);

        }

        public virtual void Delete(object id)
        {
            TEntity entity = this.DBSet.Find(id);
            this.Delete(entity);
        }

        public virtual void Attach(TEntity entity)
        {
            if (this.Context.Entry(entity).State == EntityState.Detached)
                this.DBSet.Attach(entity);
        }

        public List<TEntity> GetAll()
        {
            return this.Context.Set<TEntity>().ToList();
        }

        public virtual void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
