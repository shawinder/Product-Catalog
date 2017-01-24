#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  BaseRepository.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Repositories
{
    #region Includes

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Data.Entity;
    using System.Linq.Expressions;

    using Interfaces;

    #endregion

    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected CatalogContext Context { get; private set; }
        protected DbSet<TEntity> Set { get; set; }

        public BaseRepository(DbContext context)
        {
            Context = context as CatalogContext;
            Set = context.Set<TEntity>();
        }

        #region IRepository<TEntity> Members

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate);
        }
        
        public virtual void Insert(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = Set.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Set.Attach(entityToDelete);
            }
            Set.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Set.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = Set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return Set.Find(id);
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return Set.SqlQuery(query, parameters).ToList();
        }

        #endregion
    }
}
