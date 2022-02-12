using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;//soyut nesne ile bağlantı kurduk

        public ProductManager(IProductDal productDal) //constructor
        {
            this._productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // İŞ KODLARI
            //IProductDal productDal = new IProductDal(); //bu şekilde yazıldığında iş kodlarının tamamı bellekte çalışır. Gerçek veritabanına geçildiği(e-ticaret,sigortacılık,bankacılık uygulamalarında..)  bu kodların hepsinin değiştirilmesi gerekir.
            //Bir iş sınıfı başka sınıfları NEW LEMEZZ  !!!
            return _productDal.GetAll(); //Yukarıda yazılan kodlardan şartları geçerse eğer iş koluna diyor ki şartları sağlıyor bana ürünleri verebilirsin.
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
