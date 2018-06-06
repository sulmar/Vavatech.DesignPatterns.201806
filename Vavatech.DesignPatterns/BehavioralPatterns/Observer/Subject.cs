using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.BehavioralPatterns.Observer
{
    abstract class Subject
    {
        protected IList<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Notify(this);
            }
        }
    }

    class Stock : Subject
    {
        public string Symbol { get; set; }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                Notify();
            }
        }


        public override string ToString()
        {
            return $"{Symbol} {Price}";
        }

        public Stock(string symbol, decimal price)
        {
            this.Symbol = symbol;
            this.Price = price;
        }


    }

    interface IObserver
    {
        void Notify(Subject subject);
    }


    class MyObserver : IObserver
    {
        private string name;

        public MyObserver(string name)
        {
            this.name = name;
        }

        public void Notify(Subject subject)
        {
            Console.WriteLine($"[{name}] {subject}");

            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
    }


    class ObserverTests
    {


        // Reactive Extensions

        public static void Test2()
        {
        }

        public static void Test()
        {
            IObserver observer1 = new MyObserver("Marcin");

            Stock stock = new Stock("CHF", 3.7m);
            Stock stock2 = new Stock("USD", 4.1m);

            stock.Attach(observer1);
            stock2.Attach(observer1);

            stock.Price = 3.6m;

            IObserver observer2 = new MyObserver("Bartek");
            stock.Attach(observer2);

            stock.Price = 3.65m;
            stock.Price = 3m;


            stock.Detach(observer1);

            stock.Price = 2.8m;

        }
    }
}
