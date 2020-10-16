using Commerce.Domain;

namespace Commerce.UpdateCurrency.ApplicationServices
{
    public class UpdateCurrencyArguments
    {
        public readonly Currency Currency;
        public readonly decimal Rate;

        public UpdateCurrencyArguments(Currency currency, decimal rate)
        {
            Currency = currency;
            Rate = rate;
        }
    }
}