using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatterns.BehavioralPatterns.Problem;

namespace Vavatech.DesignPatterns.BehavioralPatterns.Strategy.Better
{
    //interface IStrategy
    //{
    //    bool CanDiscount(Order order);
    //    decimal GetDiscount(Order order);
    //}

    interface IValidatorStrategy
    {
        bool CanDiscount(Order order);
    }

    interface IDiscountStrategy
    {
        decimal GetDiscount(Order order);
    }


    class HappyHoursValidatorStrategy : IValidatorStrategy
    {
        private readonly TimeSpan beginTime;
        private readonly TimeSpan endTime;

        public HappyHoursValidatorStrategy(TimeSpan beginTime, TimeSpan endTime)
        {
            this.beginTime = beginTime;
            this.endTime = endTime;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= beginTime && order.OrderDate.TimeOfDay <= endTime;
        }
    }

    struct Period
    {
        public DateTime BeginDate;
        public DateTime EndDate;


        public Period(DateTime beginDate, DateTime endDate)
        {
            this.BeginDate = beginDate;
            this.EndDate = endDate;
        }
    }

    class PeriodValidatorStrategy : IValidatorStrategy
    {
        private readonly Period period;

        public PeriodValidatorStrategy(Period period) => this.period = period;

        public bool CanDiscount(Order order) => order.OrderDate >= period.BeginDate && order.OrderDate <= period.EndDate;
    }


    class PercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal percentage;

        public PercentageDiscountStrategy(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal GetDiscount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }


    class FixedDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal fixedAmount;

        public FixedDiscountStrategy(decimal fixedAmount)
        {
            this.fixedAmount = fixedAmount;
        }

        public decimal GetDiscount(Order order)
        {
            return fixedAmount;
        }
    }


    class OrderCalculator
    {
        private readonly IValidatorStrategy validatorStrategy;
        private readonly IDiscountStrategy discountStrategy;

        public OrderCalculator(IValidatorStrategy validatorStrategy, IDiscountStrategy discountStrategy)
        {
            this.validatorStrategy = validatorStrategy;
            this.discountStrategy = discountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (validatorStrategy.CanDiscount(order))
            {
                return discountStrategy.GetDiscount(order);
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


            // IValidatorStrategy validatorStrategy = new HappyHoursValidatorStrategy(TimeSpan.FromHours(9), TimeSpan.FromHours(17));
            IValidatorStrategy validatorStrategy = new PeriodValidatorStrategy(new Period(DateTime.Parse("2018-06-01"), DateTime.Parse("2018-06-30")));

            IDiscountStrategy discountStrategy = new PercentageDiscountStrategy(0.1m);

            OrderCalculator calculator = new OrderCalculator(validatorStrategy, discountStrategy);

            var discount = calculator.CalculateDiscount(order);

            var finalAmount = order.TotalAmount - discount;

            Console.WriteLine($"Original amount: {order.TotalAmount} discount: {discount} finalAmount: {finalAmount}");


        }
    }
}
