using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    //Abstract=>Soyut(Abstract,interface) => Referans Tutucular (uygulamalar arasındaki bağımlılıkları minimize ediyoruz)
    class Program //Concrete=>Somut
    {
        static void Main(string[] args)
        {
            //Üzerinde çıkan (IProductDal) diyor ki beni new'lemen için hangi veri yöntemi ile çalıştığımı söylemen lazım 
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

            /*
            EfProductDal efProductDal = new EfProductDal();
            Product product2 = new Product
            {
                ProductId = 5,
                CategoryId = 3,
                ProductName = "Tavuk",
                UnitPrice = 40,
                UnitsInStock = 10
            };
            
            efProductDal.Add(product2);
            ProductList(new ProductManager(efProductDal));

            efProductDal.Delete(product2);
            ProductList(productManager);
            ProductManager productManager1 = new ProductManager(new InMemoryProductDal());
            Console.WriteLine();
            CategoryList(productManager1,2);*/


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
        /*
        static void CategoryList(ProductManager productManager,int categoryId)
        {
            Console.WriteLine();
            Console.WriteLine("Product Id ".PadRight(15) + "Product Name".PadRight(15) + "Category Id".PadRight(15) + "UnitsInStock".PadRight(15) + "UnitPrice");
            Console.WriteLine("".PadRight(70, '-'));
            foreach (var product in productManager.GetAllByCategory(categoryId))
            {
                Console.WriteLine(product.ProductId.ToString().PadRight(15) + product.ProductName.PadRight(15) +
                  product.CategoryId.ToString().PadRight(15) + product.UnitsInStock.ToString().PadRight(15) + product.UnitPrice.ToString());
            }
            Console.WriteLine();
        }*/
    }
}
