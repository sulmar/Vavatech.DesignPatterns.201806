using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.CreationalPatterns.Factory
{
    abstract class Document
    {
        public int Id { get; set; }
        public string Number { get; set; }




    }

    class Invoice : Document
    {
        public decimal Tax { get; set; }
    }

    class Bill : Document
    {

    }

    class Correction : Document
    {

    }

    enum DocumentType
    {
        Bill,
        Invoice,
        Correction
    }


    class FactoryTests
    {

        public static void Test()
        {
            DocumentType documentType = DocumentType.Invoice;

            Document document = null;

            switch(documentType)
            {
                case DocumentType.Bill: document = new Bill(); break;
                case DocumentType.Invoice: document = new Invoice(); break;
                case DocumentType.Correction: document = new Correction(); break;

                default: new NotSupportedException(); break;
            }


            Console.WriteLine(document.Number);

        }


        public static void FactoryTest()
        {
            IDocumentFactory documentFactory = new DocumentFactory();

            DocumentType documentType = DocumentType.Invoice;

            Document document = documentFactory.Create(documentType);

            Console.WriteLine(document.Number);



        }
    }
}
