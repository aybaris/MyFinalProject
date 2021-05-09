using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _prodcuctDal;

        public ProductManager(IProductDal prodcuctDal)
        {
            _prodcuctDal = prodcuctDal;
        }



        public List<Product> GetAll()
        {
            //iş kodları
            return _prodcuctDal.GetAll();


        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _prodcuctDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _prodcuctDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
