using System;
using System.Collections.Generic;
using System.Linq;
using Commerce.Domain;

namespace Commerce.SqlDataAccess
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly CommerceContext _context;

        public SqlProductRepository(CommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Product> GetFeaturedProducts()
        {
            return
                from product in _context.Products
                where product.IsFeatured
                select product;
        }
    }
}