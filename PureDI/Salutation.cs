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

        public void Exclaim(string message)
        {
            _writer.Write(message);
        }
    }
}