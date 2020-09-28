using System.Collections.Generic;

namespace Commerce.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetFeaturedProducts();
    }
}