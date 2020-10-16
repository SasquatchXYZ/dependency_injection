using System;
using Commerce.Domain;

namespace Commerce.UpdateCurrency.ApplicationServices
{
    public class UpdateCurrencyCommand : ICommand
    {
        private readonly IExchangeRateProvider _provider;
        private readonly Currency _currency;
        private readonly decimal _rate;

        public UpdateCurrencyCommand(IExchangeRateProvider provider, Currency currency, decimal rate)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _currency = currency ?? throw new ArgumentNullException(nameof(currency));
            _rate = rate;
        }

        public void Execute()
        {
            decimal currentRate = GetCurrentRate(_currency);
            
            Console.WriteLine($"Old: {currentRate} {_currency} = 1 {Currency.Dollar}");
            
            _provider.UpdateExchangeRate(_currency, _rate);
            
            Console.WriteLine($"Updated: {_rate} {_currency} = 1 {Currency.Dollar}");
        }

        private decimal GetCurrentRate(Currency currency)
        {
            var dollarConversionRates = _provider.GetExchangeRatesFor(Currency.Dollar);
            return dollarConversionRates[currency];
        }
    }
}