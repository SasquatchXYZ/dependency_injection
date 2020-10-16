using System;
using System.Collections.ObjectModel;
using System.Linq;
using Commerce.Domain;

namespace Commerce.SqlDataAccess
{
    public class SqlExchangeRateProvider : IExchangeRateProvider
    {
        private readonly CommerceContext _context;

        public SqlExchangeRateProvider(CommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ReadOnlyDictionary<Currency, decimal> GetExchangeRatesFor(Currency currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));

            var rates = _context.ExchangeRates.ToArray();

            var rate = rates.Single(r => r.CurrencyCode == currency.Code);

            var dictionary = rates.ToDictionary(
                keySelector: r => new Currency(r.CurrencyCode),
                elementSelector: r => r.Rate / rate.Rate);

            return new ReadOnlyDictionary<Currency, decimal>(dictionary);
        }

        public void UpdateExchangeRate(Currency currency, decimal rate)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));

            var rates = _context.ExchangeRates.Single(r => r.CurrencyCode == currency.Code);

            rates.Rate = rate;

            _context.SaveChanges();
        }
    }
}