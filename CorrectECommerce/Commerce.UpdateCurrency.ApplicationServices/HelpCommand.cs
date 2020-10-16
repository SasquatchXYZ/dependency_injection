using System;

namespace Commerce.UpdateCurrency.ApplicationServices
{
    public class HelpCommand : ICommand
    {
        private readonly string _helpMessage;

        public HelpCommand(string helpMessage)
        {
            _helpMessage = helpMessage;
        }

        public void Execute()
        {
            Console.WriteLine(_helpMessage);
        }
    }
}