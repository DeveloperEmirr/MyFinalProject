using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //using yazıp tab tab yaptık IDispossable pattern implementation of c# // belleği hızlıca temizleme
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //Product entity git burdan eriş demek
                addedEntity.State = EntityState.Added; //ekle
                context.SaveChanges(); // kaydet gerçekleştir demek bu işlem
            }
        }

        public void Delete(Product entity)
        {
            //using yazıp tab tab yaptık IDispossable pattern implementation of c# // belleği hızlıca temizleme
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //Product entity git burdan eriş demek
                deletedEntity.State = EntityState.Deleted; //sil
                context.SaveChanges(); // kaydet gerçekleştir demek bu işlem
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
                //filtrelenen ürünü döndürecek ekranda
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() :
                    context.Set<Product>().Where(filter).ToList();

                //filtre null ise yani bişe göndermezsek context.Set<Product>().ToList() burası
                //context.Set<Product>().Where(filter).ToList(); buda gönderdiğimiz filtreye göre işlem yapıyor
            }
        }

        public void Update(Product entity)
        {
            //using yazıp tab tab yaptık IDispossable pattern implementation of c# // belleği hızlıca temizleme
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //Product entity git burdan eriş demek
                updatedEntity.State = EntityState.Modified; //güncelle 
                context.SaveChanges(); // kaydet gerçekleştir demek bu işlem
            }
        }
    }
}
