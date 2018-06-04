using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.CreationalPatterns.Prototype
{
    class Invoice : ICloneable
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }

        public object Clone()
        {
            // plytka kopia
            Invoice invoice = (Invoice) this.MemberwiseClone();


            invoice.Customer = (Customer) this.Customer.Clone();

            return invoice;
        
        }

        //public object Clone()
        //{
        //    Invoice invoice = new Invoice();
        //    invoice.Id = this.Id;
        //    invoice.Customer = this.Customer;
        //    invoice.Number = this.Number;
        //    invoice.OrderDate = this.OrderDate;
        //    invoice.TotalAmount = this.TotalAmount;

        //    return invoice;
        //}
    }

    class Customer : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


    class PrototypeTest
    {
        public static void Test()
        {
            Customer customer = new Customer
            {
                Id = 1,
                Name = "Vavatech"
            };

            Invoice invoice = new Invoice
            {
                Id = 1,
                Customer = customer,
                Number = "FV 001/2018",
                OrderDate = DateTime.Now,
                TotalAmount = 100
            };


            Invoice invoice2 = new Invoice();
            invoice2.Id = invoice.Id;
            invoice2.Customer = invoice.Customer;
            invoice2.Number = invoice.Number;
            invoice2.OrderDate = invoice.OrderDate;
            invoice2.TotalAmount = invoice.TotalAmount;


            // dostosowanie
            invoice2.Id = 2;
            invoice2.Number = "FV 002/2018";
            invoice2.OrderDate = DateTime.Now;


        }


        public static void CloneTest()
        {
            Customer customer = new Customer
            {
                Id = 1,
                Name = "Vavatech"
            };

            Invoice invoice = new Invoice
            {
                Id = 1,
                Customer = customer,
                Number = "FV 001/2018",
                OrderDate = DateTime.Now,
                TotalAmount = 100
            };


            Invoice invoice2 = (Invoice) invoice.Clone();

            // dostosowanie
            invoice2.Id = 2;
            invoice2.Number = "FV 002/2018";
            invoice2.OrderDate = DateTime.Now;


        }
    }

}
