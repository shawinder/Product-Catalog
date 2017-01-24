#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  IRepository.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Repositories.Interfaces
{
    #region Includes

    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    #endregion

    public interface IRepository<TEntity>
        where TEntity : class
    {

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(object id);

        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
    }
}
