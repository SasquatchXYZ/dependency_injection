using System;
using Commerce.Domain;

namespace Commerce.UpdateCurrency.ApplicationServices
{
    public class CurrencyParser
    {
        private const string HelpMessage = "Usage: UpdateCurrency <DKK | EUR | GBP> <rate>.";

        private readonly IExchangeRateProvider _provider;

        public CurrencyParser(IExchangeRateProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public ICommand Parse(string[] args)
        {
            if (args == null || args.Length != 2 || !decimal.TryParse(args[1], out var rate))
            {
                return new HelpCommand(HelpMessage);
            }

            var currencyCode = args[0];

            return new UpdateCurrencyCommand(_provider, new Currency(currencyCode), rate);
        }
    }
}