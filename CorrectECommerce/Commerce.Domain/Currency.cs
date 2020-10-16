using System;

namespace Commerce.Domain
{
    public class Currency
    {
        public readonly string Code;

        public Currency(string code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        public static readonly Currency Dollar = new Currency("USD");
        public static readonly Currency Euro = new Currency("EUR");
        public static readonly Currency Pound = new Currency("GBP");
    }
}