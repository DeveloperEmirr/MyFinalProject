using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //hangi keyi yollarsak o keyin datasını getir diyoruz.
        T Get<T>(string key);

        object Get(string key);

        //cacheye ekleme işlemi yapabiliriz.
        void Add(string key, object value, int druation);

        //cachede varmı yokmu ona göre işlem yapma metodu için
        bool IsAdd(string key);

        //gönderme işlemi yapıcaz
        void Remove(string key);

        //metotisimine göre gönderme işlemi yapıcaz işte başında get olan içinde Category olan gibi
        void RemoveByPattern(string pattern);
    }
}
