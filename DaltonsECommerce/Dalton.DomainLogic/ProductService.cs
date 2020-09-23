using System.Collections.Generic;
using System.Linq;
using Dalton.SqlAccess;

namespace Dalton.DomainLogic
{
    public class ProductService
    {
        private readonly CommerceContext _dbContext;

        public ProductService()
        {
            _dbContext = new CommerceContext();
        }

        public IEnumerable<Product> GetFeaturedProducts(bool isCustomerPreferred)
        {
            decimal discount = isCustomerPreferred
                ? 0.95m
                : 1;

            var featuredProducts =
                from product in _dbContext.Products
                where product.IsFeatured
                select product;

            return
                from product in
                    featuredProducts.AsEnumerable()
                select new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    IsFeatured = product.IsFeatured,
                    UnitPrice = product.UnitPrice * discount
                };
        }
    }
}