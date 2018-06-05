using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatterns.BehavioralPatterns.Problem;

namespace Vavatech.DesignPatterns.StructuralPatterns.Decorator
{
    interface IDiscount
    {
        decimal GetDiscount(Order order);
    }

    abstract class Decorator : IDiscount
    {
        private IDiscount discount;

        public Decorator(IDiscount discount)
        {
            this.discount = discount;
        }

        public virtual decimal GetDiscount(Order order)
        {
            if (discount != null)
            {
                return discount.GetDiscount(order);
            }
            else
                return 0;
        }
    }

    class FixedDiscount : Decorator
    {
        private readonly decimal fixedAmount;

        public FixedDiscount(IDiscount discount, decimal fixedAmount) 
            : base(discount)
        {
            this.fixedAmount = fixedAmount;
        }

        public override decimal GetDiscount(Order order)
        {
            decimal discount = base.GetDiscount(order);

            return discount + fixedAmount;
        }
    }

    class PercentageDiscount : Decorator
    {
        private readonly decimal percentage;

        public PercentageDiscount(IDiscount discount, decimal percentage) 
            : base(discount)
        {
            this.percentage = percentage;
        }

        public override decimal GetDiscount(Order order)
        {
            var discount = base.GetDiscount(order);

            return (order.TotalAmount - discount) * percentage;
        }


    }

    class OrderCalculator
    {
        private readonly IDiscount discount;

        public OrderCalculator(IDiscount discount)
        {
            this.discount = discount;
        }

        public decimal CalculateDiscount(Order order)
        {
            return discount.GetDiscount(order);
        }
    }
   


    class DecoratorTests
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

            IDiscount discount = new PercentageDiscount(
                                    new PercentageDiscount(
                                        new FixedDiscount(null, 10m), 0.2m), 0.1m);

            decimal result = discount.GetDiscount(order);

            OrderCalculator orderCalculator = new OrderCalculator(discount);

            decimal discountAmount = orderCalculator.CalculateDiscount(order);



        }



        public static void StreamTest()
        {
            string text = "Hello World";
            byte[] buffer = Encoding.ASCII.GetBytes(text);

            // Compression
            Stream stream = new GZipStream(new FileStream("output.txt", FileMode.Create), CompressionMode.Compress);

            stream.Write(buffer, 0, buffer.Length);

            stream.Close();




            //stream.Read(buffer, 0, buffer.Length);

            //string content = System.Text.Encoding.ASCII.GetString(buffer);





        }
    }
}
