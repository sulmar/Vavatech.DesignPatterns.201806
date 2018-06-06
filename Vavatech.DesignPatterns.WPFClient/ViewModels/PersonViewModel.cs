using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatterns.WPFClient.IServices;
using Vavatech.DesignPatterns.WPFClient.MockServices;
using Vavatech.DesignPatterns.WPFClient.Models;

namespace Vavatech.DesignPatterns.WPFClient.ViewModels
{
    class PersonViewModel
    {
        public Person Person { get; set; }

        private readonly IPersonsService personsService;


        public PersonViewModel()
            : this(new MockPersonsService())
        {
        }

        public PersonViewModel(IPersonsService personsService)
        {
            this.personsService = personsService;

            Load();

        }

        private void Load()
        {
            Person = personsService.Get(100);
        }

    }
}
