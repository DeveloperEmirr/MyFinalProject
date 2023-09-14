using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();//birisi senden ICacheManager isterse MemoryCacheManager ver demek oluyor bu
            serviceCollection.AddMemoryCache(); // bunun karşılığı  MemoryCacheManager deki    IMemoryCache _memoryCache; tir
        }
    }
}
