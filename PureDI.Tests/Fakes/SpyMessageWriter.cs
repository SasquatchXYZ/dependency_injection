namespace PureDI.Tests.Fakes
{
    public class SpyMessageWriter : IMessageWriter
    {
        public string WrittenMessage { get; private set; }

        public void Write(string message)
        {
            WrittenMessage += message;
            MessageCount++;
        }

        public int MessageCount { get; private set; }
    }
}