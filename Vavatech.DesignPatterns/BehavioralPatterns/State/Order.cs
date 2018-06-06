using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.BehavioralPatterns.State
{
    class Order
    {
        public int Id { get; set; }
        // public OrderState State { get; set; }

        private OrderState state;

        public OrderState State
        {
            get { return state; }
            set
            {
                if (value == OrderState.Paid && state == OrderState.Created)
                {
                    state = value;
                }


            }
        }


        public Order()
        {
            State = OrderState.Created;
        }

    }


    enum OrderState
    {
        Created = 10,
        Paid = 20,
        InProgress,
        Sent,
        Delivered,
        Canceled
    }


    class StateTests
    {
        public static void Test()
        {
            Order order = new Order();

            Payment(order);

            Sent(order);
        }

        private static void Payment(Order order)
        {
            if (order.State == OrderState.Created)
            {
                order.State = OrderState.Paid;
            }
        }


        private static void Sent(Order order)
        {
            if (order.State == OrderState.InProgress)
            {
                order.State = OrderState.Sent;

                Console.WriteLine("Wysłano twoje zamowienie...");
            }
        }


        private static void Cancel(Order order)
        {
            order.State = OrderState.Canceled;

            Console.WriteLine("Anulowane zamowienie");
        }
    }


    interface ICommand
    {
        void Execute();

        bool CanExecute();
    }

    class SendCommand : ICommand
    {
        private readonly Order order;

        public SendCommand(Order order)
        {
            this.order = order;
        }

        public bool CanExecute()
        {
            return order.State == OrderState.InProgress;
        }

        public void Execute()
        {
            order.State = OrderState.Sent;

            Console.WriteLine("Wysłano twoje zamowienie...");
        }
    }
}
