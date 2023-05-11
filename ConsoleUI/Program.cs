using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ben inmemory çalışıcam demek
            ProductManager productManager = new ProductManager(new InMemoryProductDal());

            foreach (var product in productManager.GettAll())
            {
                Console.WriteLine(product.ProductName);
                
            }
        }
    }
}
