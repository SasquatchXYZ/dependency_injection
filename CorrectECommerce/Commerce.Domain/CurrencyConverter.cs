using System;

namespace Commerce.Domain
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly IExchangeRateProvider _exchangeRateProvider;

        public CurrencyConverter(IExchangeRateProvider exchangeRateProvider)
        {
            _exchangeRateProvider = exchangeRateProvider ?? throw new ArgumentNullException(nameof(exchangeRateProvider));
        }

        public Money Exchange(Money money, Currency targetCurrency)
        {
            if (money == null)
                throw new ArgumentNullException(nameof(money));
            if (targetCurrency == null)
                throw new ArgumentNullException(nameof(targetCurrency));

            var exchangeRates = _exchangeRateProvider.GetExchangeRatesFor(money.Currency);
            var exchangeRate = exchangeRates[targetCurrency];

            return new Money(money.Amount * exchangeRate, targetCurrency);
        }
    }
}