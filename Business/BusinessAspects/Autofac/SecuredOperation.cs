using Business.Constants;
using Castle.DynamicProxy;
using Core.Extentions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Business.BusinessAspects.Autofac
{
    // yetki kontrolü yapmak için,,,  JWT için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; // her bir kişi context oluşturur bize

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //managerda  [SecuredOperation("product.add, admin")]; product.add, admin yazdık ya bunları ayrıp ikisini arraya atmamızı sağlıyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //ServiceTool injeksin alt yapımızı aynen okuması için oluştugumuz yapı

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //ilgili rol var ise return ediyor hata vermiyor
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            //ama öle bir rol yok ise hata mesajı ver dedik
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
