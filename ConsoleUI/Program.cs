using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ben inmemory çalışıcam demek
            ProductManager productManager = new ProductManager(new EfProductDal());
            
            foreach (var product in productManager.GetAllByUnitPrice(50,100))
            {
                Console.WriteLine(product.ProductName);
                
            }

            Console.Read();
        }
    }
}
