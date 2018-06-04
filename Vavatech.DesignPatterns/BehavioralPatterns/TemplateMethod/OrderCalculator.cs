using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.BehavioralPatterns.TemplateMethod
{

    class SeasonsOrderCalculator : OrderCalculator
    {
        private readonly DateTime beginDate;
        private readonly DateTime endDate;

        private readonly decimal percentage;

        public SeasonsOrderCalculator(DateTime beginDate, DateTime endDate, decimal percentage)
        {
            this.beginDate = beginDate;
            this.endDate = endDate;
            this.percentage = percentage;
        }

        protected override bool CanDiscount(Order order)
        {
            return order.OrderDate.Date >= beginDate && order.OrderDate.Date <= endDate;
        }

        protected override decimal GetDiscount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }

    class HappyHoursOrderCalculator : OrderCalculator
    {
        private readonly TimeSpan beginHour;
        private readonly TimeSpan endHour;

        private readonly decimal percentage;

        public HappyHoursOrderCalculator(TimeSpan beginHour, TimeSpan endHour, decimal percentage)
        {
            this.beginHour = beginHour;
            this.endHour = endHour;

            this.percentage = percentage;
        }


        override protected bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= beginHour && order.OrderDate.TimeOfDay <= endHour;
        }

        override protected decimal GetDiscount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }

    //abstract class OrderCalculator
    //{
    //    public OrderCalculator()
    //    {
    //    }

    //    public decimal CalculateDiscount(Order order)
    //    {
    //        if (CanDiscount(order))
    //        {
    //            return GetDiscount(order);
    //        }
    //        else
    //            return 0;

    //    }

    //    protected abstract bool CanDiscount(Order order);
    //    protected abstract decimal GetDiscount(Order order);
    //}

    abstract class OrderCalculator : ItemCalculator<Order>
    {

    }

    abstract class ItemCalculator<TItem>
    {
        public decimal CalculateDiscount(TItem item)
        {
            if (CanDiscount(item))
            {
                return GetDiscount(item);
            }
            else
                return 0;
        }

        protected abstract bool CanDiscount(TItem item);
        protected abstract decimal GetDiscount(TItem item);
    }


    class Order
    {
        public DateTime OrderDate { get; set; }
        public IList<OrderDetail> Details { get; set; }
        public decimal TotalAmount => Details.Sum(d => d.Amount);

        public Order()
        {
            OrderDate = DateTime.Now;
            Details = new List<OrderDetail>();
        }
    }

    class OrderDetail
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Amount => Quantity * UnitPrice;


        public OrderDetail(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.UnitPrice = product.UnitPrice;
        }

        protected OrderDetail()
        {

        }

        public void Calculate()
        {
            this.Quantity = 100;
        }
    }

    class Product
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }

    class ProblemTests
    {
        public static void Test()
        {
            Product product1 = new Product
            {
                Name = "Szkolenie",
                UnitPrice = 100,
            };

            Order order = new Order
            {
                Details = new List<OrderDetail>
                {
                    new OrderDetail(product1, 2),
                    new OrderDetail(product1, 1),
                }
            };

            Console.WriteLine($"Total amount: {order.TotalAmount}");
        }
    }
}
