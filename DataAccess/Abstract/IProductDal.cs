using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //Bu interface'e bunu(List<Product> GetAll();) eklediğimizde yandaki sarı lambada Add reference to 'Entities' çıkar
        //Başka bir katmanı kullanmak istediğimiz için referans veririz.
        //ürünleri categoriye göre filtrele
        List<Product> GetAllByCategory(int categoryId);
    }
}
