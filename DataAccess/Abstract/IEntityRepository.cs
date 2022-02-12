using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint(Genel Kısıtlama)
    //(where T:class,IEntity) => T ya IEntity olabilir ya da T, IEntity'den implemente olan birşey olabilir diyoruz.
    // class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    // new() : new'lenebilir olmalıdır.
    // IEntity INTERFACE OLDUGUNDAN  NEW'LENEMEZ.
    public interface IEntityRepository<T> where T:class,IEntity,new()//class dediğimiz zaman referans tipli bu nedenle T yerine int,string yazamayız.
    {
        //Expression<Func<T,bool>> filter=null => FİLTRELEME(p=>p.productId=2)
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//filtre vermeyedebiliriz.Yani tüm data'yı verebiliriz
        T Get(Expression<Func<T, bool>> filter);//burada filtre zorunlu
        void Add(T entity);
        void UpDate(T entity);
        void Delete(T entity);
    }
}
