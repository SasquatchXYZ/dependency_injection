using System.Globalization;
using Commerce.Domain;

namespace Commerce.Web.Models
{
    public class ProductViewModel
    {
        private static readonly CultureInfo _priceCulture = new CultureInfo("en-US");

        public ProductViewModel(DiscountedProduct product)
        {
            Name = product.Name;
            UnitPrice = product.UnitPrice;
        }

        public string Name { get; }
        public decimal UnitPrice { get; }
        public string SummaryText => string.Format(_priceCulture, "{0} ({1:C})", Name, UnitPrice);
    }
}