using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.AutoFac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        // TransactionScope işlemi örneğin ben birine 10 tl gönderdim ve o 10 tl benim hesabumndan çıktı gönderdiğim kişinin hesabına geçmedi
        //burada geri para iade işlemi olmalı ve paranın tekrar hesabıma yatması gerekmektedir.
        //TransactionScope işlemide bu yapılan işlemleriniptal edilmesini sağlamaktadır.

        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    //sıkıntı yoksa işlemde işlem yapılır
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    //sıkıntı varsa işlemde  işlemi geri alıyor iptal ediyor demek
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
