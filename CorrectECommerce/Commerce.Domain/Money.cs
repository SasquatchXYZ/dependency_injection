using System;

namespace Commerce.Domain
{
    public class Money
    {
        public readonly decimal Amount;
        public readonly Currency Currency;

        public Money(decimal amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }
    }
}