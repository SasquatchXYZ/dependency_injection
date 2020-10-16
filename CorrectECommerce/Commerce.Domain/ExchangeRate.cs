using System;

namespace Commerce.Domain
{
    public class ExchangeRate
    {
        public Guid Id { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
    }
}