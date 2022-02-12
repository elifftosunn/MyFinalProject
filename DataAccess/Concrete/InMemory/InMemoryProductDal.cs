using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //InMemoryProductDal => IProductDal'ın bir implementasyonudur.
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()//(constructor)BELLEKTE referans aldığı zaman çalışacak olan koddur.
        {
            _products = new List<Product> {
                new Product{ ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ ProductId=5,CategoryId=3,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        { 
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //System.Linq kütüphanesi
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void UpDate(Product product)
        {
            Product productToUpdate = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int CategoryId)
        {
            return _products.Where(p => p.CategoryId == CategoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
    // _products.Remove(product); => bu şekilde listeden silinmemesinin nedeni referans tipli olması yani referans tipi referans tip üzerinden silinir. Biz böyle yapınca arayüzden gönderiyoruz ve referansları farklı olduğundan kesinlikle silmez isterse id'si aynı olsa bilee !!!
    //Ama biz değer tip olarak gönderseydik(bool,string,int ,double gibi) ozaman silerdi.


    /*
    Product productToDelete = null;
    foreach (var p in _products)
    {
        if (product.ProductId == p.ProductId)
        {
            productToDelete = p;
        }
    }
    _products.Remove(productToDelete);*/
    //LINQ - Language Integrated Query => Bu yapı ile liste bazlı yapıları SQL gibi sorgulayabiliyoruz.
    //SingleOrDefault => (foreach) listeyi tek tek dolaşmaya yarar !!!
}
