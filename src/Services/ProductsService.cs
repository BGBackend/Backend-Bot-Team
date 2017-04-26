using BackendBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendBot.Services
{
    public class ProductsService
    {
        public static Repositories.InMemoryProductRepository _productRepository = new Repositories.InMemoryProductRepository();

        public static IEnumerable<Product> GetProducts()
        {
            return _productRepository.FindAll();
        }

        public static Product GetProductyByName(string productName)
        {
            return _productRepository.GetByName(productName);
        }
    }
}