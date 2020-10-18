using API.Entities;
using API.Interfaces;
using API.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetListOfProductsTypePass()
        {
            IProductService service = new ProductService();
            var list = service.GetAllProducts().Result;
            Assert.IsTrue(typeof(List<IProduct>) == list.GetType());
        }

        [Test]
        public void TestAddProductCountListPass()
        {
            IProductService service = new ProductService();
            service.AddProduct(new Product { Id = 0, Type = 2, Name = "Prueba", Expiration = new DateTime(2020, 10, 5) });
            var list = service.GetAllProducts().Result;
            Assert.IsTrue(list.Count == 6);
        }

        [Test]
        public void TestAddProductIdNewProductPass()
        {
            IProductService service = new ProductService();
            service.AddProduct(new Product { Id = 0, Type = 2, Name = "Prueba", Expiration = new DateTime(2020, 10, 5) });
            var list = service.GetAllProducts().Result;
            Assert.IsTrue(list[5].Id > 0);
        }

        [Test]
        public void TestDeleteProductIdNotFoundFail()
        {
            IProductService service = new ProductService();
            var result = service.DeleteProduct(0);
            Assert.IsTrue(result > 0);
        }
    }
}