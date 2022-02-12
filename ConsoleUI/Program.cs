using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program 
    {
        static void Main(string[] args)
        {
            
            ProductManager productManager = new ProductManager(new EfProductDal());
            //ProductList(productManager);
            Console.WriteLine();
            Console.WriteLine("Product Id ".PadRight(15) + "Product Name".PadRight(15) + "Category Id".PadRight(15) + "UnitsInStock".PadRight(15) + "UnitPrice");
            Console.WriteLine("".PadRight(70, '-'));
            foreach (var product in productManager.GetByUnitPrice(50,100))
            {
                Console.WriteLine(product.ProductId.ToString().PadRight(15) + product.ProductName.PadRight(15) +
                  product.CategoryId.ToString().PadRight(15) + product.UnitsInStock.ToString().PadRight(15) + product.UnitPrice.ToString());
            }
            Console.WriteLine();


        }
        static void ProductList(ProductManager productManager)
        {
            Console.WriteLine();
            Console.WriteLine("Product Id ".PadRight(15) + "Product Name".PadRight(15) + "Category Id".PadRight(15) + "UnitsInStock".PadRight(15) + "UnitPrice");
            Console.WriteLine("".PadRight(70, '-'));
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductId.ToString().PadRight(15) + product.ProductName.PadRight(15) +
                  product.CategoryId.ToString().PadRight(15) + product.UnitsInStock.ToString().PadRight(15) + product.UnitPrice.ToString());
            }
            Console.WriteLine();
        }
    }
}
