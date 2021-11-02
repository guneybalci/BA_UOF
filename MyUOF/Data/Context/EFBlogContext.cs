using MyUOF.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUOF.Data.Context
{
  public  class EFBlogContext:DbContext
    {
        public EFBlogContext():base("BenimConn")
        {


        }
        //tables

        public DbSet<Article> Article{ get; set; }
        public DbSet<User> User{ get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent api 
            base.OnModelCreating(modelBuilder);
        }
    }
}
