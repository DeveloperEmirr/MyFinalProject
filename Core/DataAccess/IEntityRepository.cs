using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess //core katmanları diğer katmanları referans almaz
{
    //generic constraint : kısıtlama getirmek temek
    //where  T:class,IEntity bu sadece Ientitynin eşlik ettiği clasları kullan dedik burada
    //new() newlenebilir olmalı dedik ve where  T:class,IEntity,new() İnterface kullanma sadece
    //Ientitynin eşlik ettiği clasları kullan dedik
    public interface IEntityRepository<T> where  T:class,IEntity,new()
    {
        //Expression<Func<T,bool>>filter=null filtreleme işlemi yapmamızı sağlıyor
        List<T> GetAll(Expression<Func<T,bool>>filter=null);//filter=null yazınca istersek tüm datayı getirebiliriz demek
        T Get(Expression<Func<T, bool>> filter); //filter ona filtreleme vermemiz lazım
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
