using MyUOF.Data.Context;
using MyUOF.Data.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUOF.Data.UOW
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EFBlogContext _dbcontext;

        public EFUnitOfWork(EFBlogContext dbContext)
        {
            Database.SetInitializer<EFBlogContext>(null);
            if (dbContext == null)
                throw new ArgumentNullException("db null olmamalı ");
            _dbcontext = dbContext;
        }
        public void Dispose()
        {
            //GC 
            _dbcontext.Dispose();
            GC.SuppressFinalize(this);
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_dbcontext);
        }

        public int SaveChanges()
        {
            try
            {
                //tran
                //TransactionScope class
             return   _dbcontext.SaveChanges();

            }
            catch (Exception ex)
            {
                //log 
                //validation ex handle 
            }
            return 0;      
        }
    }
}
