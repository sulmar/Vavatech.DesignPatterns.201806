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
}
