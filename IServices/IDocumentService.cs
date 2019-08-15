using System.Threading.Tasks;
using Document.Domain;
using Microsoft.AspNet.OData;

namespace Document.Interface.Service
{
    public interface IDocumentService
    {
        Task<int> Insert(DocumentModel document);
        Task<DocumentModel> GetId(int code);
        Task Edit(Delta<DocumentModel> document, DocumentModel entity);
    }
}