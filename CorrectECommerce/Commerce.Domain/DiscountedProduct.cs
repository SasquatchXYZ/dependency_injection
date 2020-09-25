using System;

namespace Commerce.Domain
{
    public class DiscountedProduct
    {
        public string Name { get; }

        public decimal UnitPrice { get; }

        public DiscountedProduct(string name, decimal unitPrice)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            UnitPrice = unitPrice;
        }
    }
}