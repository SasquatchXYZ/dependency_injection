using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ProductManagement.Domain;

namespace ProductManagement.DataAccess
{
    class FakeProductRepository : IProductRepository
    {
        private readonly Dictionary<Guid, string> _products = new Dictionary<Guid, string>();

        public FakeProductRepository()
        {
            AddTestProducts();
        }

        public IEnumerable<Product> GetAll() => _products.Values.Select(Deserialize);
        public Product GetById(Guid id) => Deserialize(_products[id]);
        public void Insert(Product product) => _products.Add(product.Id, Serialize(product));
        public void Update(Product product) => _products[product.Id] = Serialize(product);
        public void Delete(Guid id) => _products.Remove(id);

        private static string Serialize(Product p) => JsonConvert.SerializeObject(p);
        private static Product Deserialize(string json) => JsonConvert.DeserializeObject<Product>(json);

        private void AddTestProducts()
        {
            Insert(new Product {Id = Guid.NewGuid(), Name = "Criollo Chocolate", UnitPrice = 34.95m});
            Insert(new Product {Id = Guid.NewGuid(), Name = "Maldon Sea Salt", UnitPrice = 19.50m});
            Insert(new Product {Id = Guid.NewGuid(), Name = "Gruyere", UnitPrice = 48.50m});
            Insert(new Product {Id = Guid.NewGuid(), Name = "White Asparagus", UnitPrice = 39.80m});
            Insert(new Product {Id = Guid.NewGuid(), Name = "Anchovies", UnitPrice = 18.75m});
        }
    }
}