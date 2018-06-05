using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Vavatech.DesignPatterns.BehavioralPatterns.Command
{
    class MailSender
    {
        private string from;

        public void Send(string from, string to)
        {
            this.from = from;

            Console.WriteLine($"Sending from {from} to: {to}");
        }


        public bool CanSend()
        {
            return true;
        }


        public void Print()
        {

        }


        public bool CanPrint()
        {
            return false;
        }
    }


    

    interface ICommand
    {
        void Execute();
        bool CanExecute();
    }

    class PrintCommand : ICommand
    {
        public bool CanExecute()
        {
            return true;

           // System.Windows.Input.ICommand
        }

        public void Execute()
        {
            Console.WriteLine("Printing...");
        }
    }


    class Message
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    class SendCommand : ICommand
    {
        private readonly Message message;

        public SendCommand(Message message)
        {
            this.message = message;
        }

        public bool CanExecute()
        {
            return !string.IsNullOrEmpty(message.From) && !string.IsNullOrEmpty(message.To);
        }

        public void Execute()
        {
            Console.WriteLine($"Sending from {message.From} to: {message.To}");
        }
    }

    class CommandTests
    {

        public static void Test()
        {
            //ICommand command = new SendCommand("marcin.sulecki@gmail.com", "marcin.sulecki@gmail.com");

            //if (command.CanExecute())
            //{
            //    command.Execute();
            //}
        }
    }

}
