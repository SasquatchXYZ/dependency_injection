using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PureDI
{
    class Program
    {
        static void Main(string[] args)
        {
            // IMessageWriter writer = new ConsoleMessageWriter();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string typeName = configuration["messageWriter"];
            Type type = Type.GetType(typeName, throwOnError: true);

            IMessageWriter writer = (IMessageWriter) Activator.CreateInstance(type);

            var salutation = new Salutation(writer);
            salutation.Exclaim("Hello DI!");
        }
    }
}