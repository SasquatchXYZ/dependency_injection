using System.Collections.ObjectModel;

namespace Commerce.Domain
{
    public interface IExchangeRateProvider
    {
        ReadOnlyDictionary<Currency, decimal> GetExchangeRatesFor(Currency currency);

        void UpdateExchangeRate(Currency currency, decimal rate);
    }
}