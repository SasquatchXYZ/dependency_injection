using System;
using Commerce.SqlDataAccess;
using Commerce.UpdateCurrency.ApplicationServices;
using Microsoft.Extensions.Configuration;

namespace Commerce.UpdateCurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = LoadConnectionString();

            CurrencyParser parser = CreateCurrencyParser(connectionString);
            ICommand command = parser.Parse(args);
            command.Execute();
        }

        private static string LoadConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            return config.GetConnectionString("CommerceConnectionString");
        }

        private static CurrencyParser CreateCurrencyParser(string connectionString)
        {
            var provider = new SqlExchangeRateProvider(new CommerceContext(connectionString));

            return new CurrencyParser(provider);
        }
    }
}