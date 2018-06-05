using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.BehavioralPatterns.Problem
{


    class OrderCalculator
    {
        private TimeSpan beginHour = TimeSpan.FromHours(14.5);
        private TimeSpan endHour = TimeSpan.FromHours(16);

        public decimal CalculateDiscount(Order order)
        {
            // 14..16 h -> 10%
            // if (14 <= order.OrderDate.Hour && order.OrderDate.Hour <= 16)

            //if (order.OrderDate.TimeOfDay >= beginHour && order.OrderDate.TimeOfDay <= endHour)
            //{
            //    return order.TotalAmount * 0.1m;
            //}
            //else
            //    return 0;

            if (CanDiscount(order))
            {
                return GetDiscount(order);
            }
            else
                return 0;

        }


        private bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= beginHour && order.OrderDate.TimeOfDay <= endHour;
        }

        private decimal GetDiscount(Order order)
        {
            return order.TotalAmount * 0.1m;
        }

    }


    class Order
    {
        public DateTime OrderDate { get; set; }
        public IList<OrderDetail> Details { get; set; }
        public decimal TotalAmount => Details.Sum(d => d.Amount);


        // public decimal DiscountAmount { get; set; }

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
