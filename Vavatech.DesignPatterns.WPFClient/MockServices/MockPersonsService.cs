using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatterns.WPFClient.IServices;
using Vavatech.DesignPatterns.WPFClient.Models;

namespace Vavatech.DesignPatterns.WPFClient.MockServices
{
    class MockPersonsService : IPersonsService
    {
        public Person Get(int id)
        {
            var person = new Person
            {
                FirstName = "Marcin",
                LastName = "Sulecki"
            };

            return person;
        }
    }
}
