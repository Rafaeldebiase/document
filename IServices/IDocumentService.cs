using System.Threading.Tasks;
using Document.Domain;


namespace Document.Interface.Service
{
    public interface IDocumentService
    {
        Task<int> Insert(DocumentModel document);
    }
}