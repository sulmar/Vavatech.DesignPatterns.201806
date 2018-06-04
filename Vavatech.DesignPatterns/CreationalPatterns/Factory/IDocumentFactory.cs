using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.CreationalPatterns.Factory
{
    interface IDocumentFactory
    {
        Document Create(DocumentType documentType);
    }


    class DocumentFactory : IDocumentFactory
    {
        public Document Create(DocumentType documentType)
        {
            Document document = null;

            switch (documentType)
            {
                case DocumentType.Bill: document = new Bill(); break;
                case DocumentType.Invoice: document = new Invoice(); break;
                case DocumentType.Correction: document = new Correction(); break;

                default: new NotSupportedException(); break;
            }

            return document;
        }
    }
}
