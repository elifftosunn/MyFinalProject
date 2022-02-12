using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        List<Product> _products;
        public void Add(Product entity)
        {
            // (using) => IDispossable pattern implementation c#
            //using içine yazılan nesneler anında bellekten atılıyor. Yani (NorthwindContext context=new NorthwindContext()) işi bitince bellekten atılacak.
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); // Bu veri kaynağından(benim  gönderdiğim Productan bir tane nesneyi eşleştir.Ama ekleme olduğundan herhangi bir şeyi eşleştirmicek direk eklicek.)
                addedEntity.State = EntityState.Added; //ekleme olarak durumu set et, sonra da ekle
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); 
                deletedEntity.State = EntityState.Deleted; 
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); //tek data getiriyor
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context =new NorthwindContext())
            {
                // context.Set<Product>().ToList() => select * from products
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void UpDate(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
