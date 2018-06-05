using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.CreationalPatterns.FluentApi
{
    class Radio
    {
        private string from;
        private string to;
        private string body;
        private IList<string> cc;

        public Radio()
        {
            cc = new List<string>();
        }

        public Radio Body(string message)
        {
            this.body = message;

            return this;
        }

        public Radio To(string to)
        {
            if (string.IsNullOrEmpty(this.to))
            {
                throw new InvalidOperationException("Pole do jest już wypełnione.");
            }

            this.to = to;

            return this;
        }


        public Radio CC(string recipient)
        {
            this.cc.Add(recipient);

            return this;
        }


        public Radio From(string from)
        {
            this.from = from;

            return this;
        }

        public void Send()
        {
            if (string.IsNullOrEmpty(to))
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (string.IsNullOrEmpty(body))
            {
                throw new ArgumentNullException(nameof(body));
            }


            Console.WriteLine($"Send [{from}] -> [{to}] : {body}");

            foreach (var recipient in cc)
            {
                Console.WriteLine($"Send [{from}] -> [{recipient}] : {body}");
            }
        }

    }


    class FluentApiTests
    {
        public static void Test()
        {
            try
            {
                Radio radio = new Radio();

                radio
                    .From("marcin")
                    // .To("bartek")
                    .CC("kasia")
                    .CC("mama")
                    .CC("tata")
                    .Body("Hello Bartek!")
                    .Send();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                throw;
            }
        }
    }
}
