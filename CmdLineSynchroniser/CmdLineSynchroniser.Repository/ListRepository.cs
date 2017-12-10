using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CmdLineSynchroniser.IRepository;

namespace CmdLineSynchroniser.Repository
{
    public class ListRepository<TEntity>:IRepository<TEntity> where TEntity:class, new()
    {
        protected IList<TEntity> Entities { get; set; }=new List<TEntity>();

        public virtual IEnumerable<TEntity> GetList()
        {
            return Entities.AsEnumerable();
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate.Compile());
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate.Compile()).Count();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities?.Where(predicate.Compile()).FirstOrDefault();
        }

        public virtual void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var index = Entities.IndexOf(entity);
            if (index >= 0)
            {
                Entities[index] = entity;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public virtual void Save()
        {
            
        }
    }
}
