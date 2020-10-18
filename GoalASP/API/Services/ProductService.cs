using API.Entities;
using API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProductService: IProductService
    {
        List<IProduct> _products;

        public ProductService()
        {
            _products = new List<IProduct>() {
                new Product(){ Id = 1, Name = "Mascarilla", Expiration = new DateTime(2021, 1, 31), Type = 1 },
                new Product(){ Id = 2, Name = "Gel", Expiration = new DateTime(2020, 12, 1), Type = 1 },
                new Product(){ Id = 3, Name = "Guante", Expiration = new DateTime(2021, 12, 1), Type = 1 },
                new Product(){ Id = 4, Name = "Bata", Expiration = new DateTime(2022, 3, 24), Type = 1 },
                new Product(){ Id = 5, Name = "Suero", Expiration = new DateTime(2020, 10, 20), Type = 1 }
            };
        }
        public int AddProduct(IProductExpiration product)
        {
            int lastId = _products.Last().Id;
            _products.Add(new Product() { Id = lastId + 1, Name = product.Name, Expiration = product.Expiration, Type = product.Type });
            return lastId;
        }

        public int DeleteProduct(int id)
        {
            IProduct itemFinded = _products.Find(x => x.Id == id);
            if (itemFinded != null)
            {
                _products.Remove(itemFinded);
                return id;
            }
            return 0;
        }

        public Task<List<IProduct>> GetAllProducts()
        {
            return Task.FromResult(_products);
        }

        public void NotifyProductDeleted()
        {
            throw new NotImplementedException();
        }

        public void NotifyProductExpired()
        {
            throw new NotImplementedException();
        }
    }
}
