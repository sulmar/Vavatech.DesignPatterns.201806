using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatterns.BehavioralPatterns.Problem;

namespace Vavatech.DesignPatterns.BehavioralPatterns.Strategy
{


    interface IStrategy
    {
        bool CanDiscount(Order order);
        decimal GetDiscount(Order order);
    }


    class HappyHoursStrategy : IStrategy
    {
        private readonly TimeSpan beginTime;
        private readonly TimeSpan endTime;

        private readonly decimal percentage;

        public HappyHoursStrategy(TimeSpan beginTime, TimeSpan endTime, decimal percentage)
        {
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= beginTime && order.OrderDate.TimeOfDay <= endTime;
        }

        public decimal GetDiscount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }

    class OrderCalculator
    {
        private readonly IStrategy strategy;

        public OrderCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (strategy.CanDiscount(order))
            {
                return strategy.GetDiscount(order);
            }
            else
                return 0;
        }
    }


    public class StrategyTests
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


            IStrategy strategy = new HappyHoursStrategy(TimeSpan.FromHours(14), TimeSpan.FromHours(17), 0.1m);

            OrderCalculator calculator = new OrderCalculator(strategy);

            var discount = calculator.CalculateDiscount(order);


        }
    }
}
