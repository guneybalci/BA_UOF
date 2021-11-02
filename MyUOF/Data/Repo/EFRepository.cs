using MyUOF.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyUOF.Data.Repo
{
    public class EFRepository<T> : IRepository<T> where T : class
    {

        private DbContext _dbContext;
        private DbSet<T> _dbSet;

        public EFRepository(EFBlogContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("context null olamazz");
            }

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();

        }

        public void Add(T insertedData)
        {
            _dbSet.Add(insertedData);
            //uow patterne uygun olması için .
            //  _dbContext.SaveChanges();
        }

        public void Delete(T deletedData)
        {
            // hard delete yapacağım  soft deleted
            if (deletedData.GetType().GetProperty("IsDeleted") != null)
            {
                //update et
                T entity = deletedData;
                entity.GetType().GetProperty("IsDeleted").SetValue(entity, false);
                this.Update(entity);
            }
            else
            {
                //hard delete
                //entity state 
                DbEntityEntry dbEntity = _dbContext.Entry(deletedData);

                if (dbEntity.State != EntityState.Deleted)
                {
                    dbEntity.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(deletedData);
                    _dbSet.Remove(deletedData);
                }
            }
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            if (entity == null)
                return;
            else
            {
                if (entity.GetType().GetProperty("IsDeleted") != null)
                {
                    T _entity = entity;
                    _entity.GetType().GetProperty("IsDeleted").SetValue(_entity,false);

                    this.Update(_entity);
                }
                else {
                    Delete(entity);
                }
            }

        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetByID(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public void Update(T updatedData)
        {
            _dbSet.Attach(updatedData);
            _dbContext.Entry(updatedData).State = EntityState.Modified;
        }
    }
}
