using System;

namespace PureDI
{
    public class Salutation
    {
        private readonly IMessageWriter _writer;

        public Salutation(IMessageWriter writer)
        {
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void Exclaim()
        {
            _writer.Write("Hello DI!");
        }
    }
}