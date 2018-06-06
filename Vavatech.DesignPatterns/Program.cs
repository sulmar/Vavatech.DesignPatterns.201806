using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatterns.BehavioralPatterns.Command;
using Vavatech.DesignPatterns.BehavioralPatterns.Problem;
using Vavatech.DesignPatterns.BehavioralPatterns.State;
using Vavatech.DesignPatterns.BehavioralPatterns.StateMachine;
using Vavatech.DesignPatterns.BehavioralPatterns.Strategy;
using Vavatech.DesignPatterns.CreationalPatterns.FluentApi;
using Vavatech.DesignPatterns.CreationalPatterns.Prototype;
using Vavatech.DesignPatterns.CreationalPatterns.Singleton;
using Vavatech.DesignPatterns.StructuralPatterns.Adapter;
using Vavatech.DesignPatterns.StructuralPatterns.Decorator;

namespace Vavatech.DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            StateMachineTests.LampTest();


            StateTests.Test();

            DateTimeTests.Test();

            FluentApiTests.Test();

            AdapterTests.Test();

            CommandTests.Test();

            DecoratorTests.StreamTest();

            DecoratorTests.Test();

            // BehavioralPatterns.Strategy.Better.StrategyTests.Test();

            // StrategyTests.Test();


        //    ProblemTests.Test();

            //Create("Vavatech.DesignPatterns.CreationalPatterns.Prototype.Customer");

            //ReflectionTest();

            // PrototypeTest.CloneTest();

            // SingletonTests.GenericTest();

            // SingletonTests.Test();
        }


        static object Create(string classname)
        {
            Type type = Type.GetType(classname);

            var item = Activator.CreateInstance(type);

            return item;
        }


        static void ReflectionTest()
        {
            Customer customer = new Customer
            {
                Id = 1,
                Name = "Vavatech"
            };


            Type type = customer.GetType();

            // pobieranie informacji o obiekcie
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name} {property.PropertyType}");

                // odczyt wartości
                Console.WriteLine(property.GetValue(customer));
            }

            // ustawianie wartości
            PropertyInfo propertyName = type.GetProperty("Name");
            propertyName.SetValue(customer, "Company 1");



        }
    }
}
