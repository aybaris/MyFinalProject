using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            //iş kodları (bussiness codes)
            if (product.ProductName.Length<2 )
            {
                return new ErrorResult("Ürün ismi en az 2 karakter olmalıdır")
            }
            _prodcuctDal.Add(product);
            return new Result(true, "Ürün eklendi");
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

        public Product GetById(int productId)
        {
            return _prodcuctDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _prodcuctDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _prodcuctDal.GetProductDetails();
        }
    }
}
