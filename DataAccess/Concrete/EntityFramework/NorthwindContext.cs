using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //context: db tabloları ile proje claslarını bağlamak için ypatık
    public class NorthwindContext: DbContext
    {
        //override on yazdık ve tab tusuna bastık
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;
                                        Trusted_Connection=true");//sql server kullanıcağız diyorum
            //Server=(localdb)\MSSQLLocalDB=veri tabanı bulundugu yer
            //Database=Northwind; kullacağımız tablo 
            //Truted_Connection=true" Vt nında şifreleme olmasın
            
        }

        //alttakiler de benim hangi clasım hangi tabloya karşılık geliyor onları yazıyoruz
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
