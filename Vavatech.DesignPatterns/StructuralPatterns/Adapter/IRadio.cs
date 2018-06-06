using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.StructuralPatterns.Adapter
{
    class Motorola
    {
        private bool powerOn;

        public void Init()
        {
            powerOn = true;
        }

        public void Send(string to, string message)
        {
            if (powerOn)
            {
                Console.WriteLine($"[{to}] {message}");
            }
        }

        public void Release()
        {
            powerOn = false;
        }
    }

    class Hytera
    {

        public void Print(string from, string text)
        {
            Console.WriteLine($"[{from}] {text}");
        }
    }

    interface IRadio
    {
        void Send(string to, string body);
    }

    class MotorolaAdapter : IRadio, IDisposable
    {
        private readonly Motorola adaptee;

        public MotorolaAdapter()
        {
            adaptee = new Motorola();
        }

        public void Dispose()
        {
            adaptee.Release();
        }

        public void Send(string to, string body)
        {
            adaptee.Init();

            adaptee.Send(to, body);

            adaptee.Release();
        }
    }

    class HyteraAdapter : IRadio
    {
        private readonly Hytera adaptee;

        public HyteraAdapter()
        {
            adaptee = new Hytera();
        }

        public void Send(string to, string body)
        {
            adaptee.Print(to, body);
        }
    }

    class AdapterTests
    {
        public static void Test()
        {
            using (MotorolaAdapter radio = new MotorolaAdapter())
            {
                radio.Send("marcin", "Hello World!");

                //radio = new HyteraAdapter();
                //radio.Send("bartek", "Hello Bartek");

            }



        }
    }

}
