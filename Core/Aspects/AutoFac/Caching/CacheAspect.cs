using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspects.AutoFac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;//zaman için
        private ICacheManager _cacheManager;// ı kulannıcağız

        public CacheAspect(int duration = 60)//eğer zaman verilmesse otamatik olarak 60 dk vericek
        {
            _duration = duration; //zaman verirsek atama işlemi yapıcağız belirttiğimiz zamanı
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); //ICacheManager kullanıcağız dedik
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //yukardıdaki kodun anlamı invocation=metot demek Method.ReflectedType.FullName= namespace.Business.IProductService.GettAll() demek gibi bu bir örnekti
            //{invocation.Method.Name} da metotdaki parametre adı
            var arguments = invocation.Arguments.ToList();//metotdaki parametreleri liste çevir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//parametre var sa stringe çevirip ekle yoksa null çevir
            //o değeri al keye ata
            if (_cacheManager.IsAdd(key))//key değeri var ise burası çalışır
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            //ama o key yani değer yok ise key değeri ve gönderdiğimiz süreyle birlikte oluştur diyoruz.
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
