
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter =null);//filtre verilmeyedebilir   bankacılık sisteminde tüm bilgileri görmek için

        T Get(Expression<Func<T,bool>> filter);//filtre verilecek. tek bir kişinin özel bilgilerini getirmek için

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}
