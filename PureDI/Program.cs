// V2
/*using System;
using System.IO;
using Microsoft.Extensions.Configuration;*/

using System.Security.Principal;

namespace PureDI
{
    class Program
    {
        static void Main(string[] args)
        {
            // V1
            // IMessageWriter writer = new ConsoleMessageWriter();

            // V2
            /*IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string typeName = configuration["messageWriter"];
            Type type = Type.GetType(typeName, throwOnError: true);

            IMessageWriter writer = (IMessageWriter) Activator.CreateInstance(type);*/

            IMessageWriter writer = new SecureMessageWriter(new ConsoleMessageWriter(), WindowsIdentity.GetCurrent());

            var salutation = new Salutation(writer);
            salutation.Exclaim("Hello DI!");
        }
    }
}