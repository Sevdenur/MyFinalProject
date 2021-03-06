﻿using Business.Concrete;
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
            ProductTest();
            //IoC
            //CategoryTest();                    
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal() ,new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductId + "-" + product.ProductName + "---" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine("---------------All products listed-------------------");
            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductId + "-" + product.ProductName);
            }

            Console.WriteLine("---------------Products listed by desired unit price-----------------------");
            foreach (var product in productManager.GetByUnitPrice(40, 100).Data)
            {
                Console.WriteLine(product.ProductId + "-" + product.ProductName);
            }

            Console.WriteLine("-----------------Products listed by category id--------------------");
            foreach (var product in productManager.GetAllByCategoryId(5).Data)
            {
                Console.WriteLine(product.ProductId + "-" + product.ProductName);
            }

            Console.WriteLine("-----------------Products listed with category name--------------------");
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductId + "-" + product.ProductName + "---" + product.CategoryName);
            }
        }
    }
}
