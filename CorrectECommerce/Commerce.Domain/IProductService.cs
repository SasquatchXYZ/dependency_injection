using System.Collections.Generic;

namespace Commerce.Domain
{
    public interface IProductService
    {
        IEnumerable<DiscountedProduct> GetFeaturedProducts();
    }
}