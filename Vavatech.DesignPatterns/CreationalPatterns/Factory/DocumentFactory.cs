using System;

namespace Vavatech.DesignPatterns.CreationalPatterns.Factory
{
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
