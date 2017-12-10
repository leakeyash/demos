﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CmdLineSynchroniser.IRepository
{
    public interface IRepository<TEntity> where TEntity:class 
    {
        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);

        int GetCount(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        void Save();
    }
}
