using MyUOF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyUOF.Data.Repo
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T,bool>> predicate);

        T GetByID(int id);
        T GetByID(Expression<Func<T, bool>> predicate);

        void Add(T insertedData);
        void Update(T updatedData);
        void Delete(T deletedData);
        void Delete(int id);

    }
}
