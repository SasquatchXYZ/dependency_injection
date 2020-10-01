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
    }
}