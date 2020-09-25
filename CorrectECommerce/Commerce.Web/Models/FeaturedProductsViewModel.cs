using System.Collections.Generic;

namespace Commerce.Web.Models
{
    public class FeaturedProductsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; }

        public FeaturedProductsViewModel(IEnumerable<ProductViewModel> products)
        {
            Products = products;
        }
    }
}