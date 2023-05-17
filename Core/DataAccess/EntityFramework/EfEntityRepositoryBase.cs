using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{//bana bir tablo ve context ver ona göre çalışacağım demek
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        //bu yapıyı bir kere yazdgımız zaman her projede kullanabiliriz
        public void Add(TEntity entity)
        {
            //using yazıp tab tab yaptık IDispossable pattern implementation of c# // belleği hızlıca temizleme
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //Product entity git burdan eriş demek
                addedEntity.State = EntityState.Added; //ekle
                context.SaveChanges(); // kaydet gerçekleştir demek bu işlem
            }
        }

        public void Delete(TEntity entity)
        {
            //using yazıp tab tab yaptık IDispossable pattern implementation of c# // belleği hızlıca temizleme
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //Product entity git burdan eriş demek
                deletedEntity.State = EntityState.Deleted; //sil
                context.SaveChanges(); // kaydet gerçekleştir demek bu işlem
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
                //filtrelenen ürünü döndürecek ekranda
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();

                //filtre null ise yani bişe göndermezsek context.Set<Product>().ToList() burası
                //context.Set<Product>().Where(filter).ToList(); buda gönderdiğimiz filtreye göre işlem yapıyor
            }
        }

        public void Update(TEntity entity)
        {
            //using yazıp tab tab yaptık IDispossable pattern implementation of c# // belleği hızlıca temizleme
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //Product entity git burdan eriş demek
                updatedEntity.State = EntityState.Modified; //güncelle 
                context.SaveChanges(); // kaydet gerçekleştir demek bu işlem
            }
        }
    }
}
