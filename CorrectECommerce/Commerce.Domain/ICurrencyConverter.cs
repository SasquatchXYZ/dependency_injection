namespace Commerce.Domain
{
    public interface ICurrencyConverter
    {
        Money Exchange(Money money, Currency targetCurrency);
    }
}