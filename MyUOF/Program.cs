using MyUOF.Data.Context;
using MyUOF.Data.Models;
using MyUOF.Data.Repo;
using MyUOF.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUOF
{
    class Program
    {
        static void Main(string[] args)
        {

            //repository  ve Unit of Work Patterns 
            //Crud

            UserEkle();

            Console.ReadKey();

        }

        private static void UserEkle()
        {
            EFBlogContext _dbcontex = new EFBlogContext();
            IUnitOfWork _uow = new EFUnitOfWork(_dbcontex);
            IRepository<User> _urepo = new EFRepository<User>(_dbcontex);
            _urepo.Add(new User()
            {
                CreatedDate = DateTime.Now,
                Email="m@m.com",
                FirstName="melike",
                IsDeleted=true,
                LastName="memiş",
                Password="123"

            });
            Console.WriteLine(_uow.SaveChanges()>0?"veri eklendi":"hata oluştu");            

        }
    }
}
