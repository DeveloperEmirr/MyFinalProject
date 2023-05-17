using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {   //IEntityRepository<Product> sen product dal kullan dedik kodları IEntityRepository yazdık

        List<ProductDetailDto> GetProductDetailDtos(); //ürünün detaylarını getir dedik burada

    }
}

//code refactoring
