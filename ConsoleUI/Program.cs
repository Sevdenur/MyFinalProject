using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            Console.WriteLine("---------------All products listed-------------------");
            foreach (var product in productManager.GetAll())
            {           
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("---------------Products listed by desired unit price-----------------------");
            foreach (var product in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("-----------------Products listed by category id--------------------");
            foreach (var product in productManager.GetAllByCategoryId(5))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
