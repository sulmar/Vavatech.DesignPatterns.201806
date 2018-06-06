using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.BehavioralPatterns.Repository
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public IList<Order> Orders { get; set; }
    }

    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }


    class Order
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    abstract class SearchCriteria
    {

    }

    struct Period
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    struct Range
    {
        public decimal? From { get; set; }
        public decimal? To { get; set; }
    }

    class OrderSearchCriteria
    {
        public Period Period { get; set; }
        public Range TotalAmountRange { get; set; }
    }

    class CustomerSearchCriteria
    {
        public string city { get; set; }
        public string country { get; set; }
        public bool IsDeleted { get; set; }
    }

    interface IOrdersRepository : IItemsRepository<Order>
    {
        IList<Order> Get(OrderSearchCriteria criteria);
    }

    interface ICustomersRepository : IItemsRepository<Customer>
    {
        IList<Customer> Get(CustomerSearchCriteria criteria);
    }

    interface IUsersRepository : IItemsRepository<User>
    {
    }


    class MockCustomersRepository : ICustomersRepository
    {
        private IList<Customer> customers = new List<Customer>();

        public void Add(Customer item)
        {
            customers.Add(item);
        }

        public IList<Customer> Get(CustomerSearchCriteria criteria)
        {
            var query = customers.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.country))
            {
                query = customers.Where(c => c.Country == criteria.country).AsQueryable();
            }

            if (!string.IsNullOrEmpty(criteria.city))
            {
                query = customers.Where(c => c.City == criteria.city).AsQueryable();
            }

            return query.ToList();
        }

        public IList<Customer> Get2(CustomerSearchCriteria criteria)
        {
            var query = customers;

            if (!string.IsNullOrEmpty(criteria.country))
            {
                query = customers.Where(c => c.Country == criteria.country).ToList();
            }

            if (!string.IsNullOrEmpty(criteria.city))
            {
                query = customers.Where(c => c.City == criteria.city).ToList();
            }

            return query;
        }

        public IList<Customer> Get()
        {
            return customers;
        }

        public void Remove(int id)
        {
            var customer = customers.SingleOrDefault(c => c.Id == id);

            customers.Remove(customer);
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }


    interface IItemsRepository<TItem>
    {
        IList<TItem> Get();
        void Add(TItem item);
        void Update(TItem item);
        void Remove(int id);
    }


    //class MyContext : DbContext
    //{
    //    public DbSet<Customer> Customers { get; set; }
    //}

    class RepositoryTests
    {
        static void GetCustomersTest()
        {

            // 1. Pobierz klientow

            ICustomersRepository customersRepository = new MockCustomersRepository();
            var customers = customersRepository.Get();


            // 2. Wyswietl

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }


        }
    }
}
