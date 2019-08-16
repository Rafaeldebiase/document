using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Microsoft.AspNet.OData;

namespace Document.Interface.Service
{
    public interface IDocumentService
    {
        Task<int> Insert(DocumentModel document);
        Task<DocumentModel> GetId(int code);
        Task<int> EditAsync(Delta<DocumentModel> document, DocumentModel documentDto);
    }
}