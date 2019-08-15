using System.Threading.Tasks;
using Document.Dto;

namespace Document.Interface.Service
{
    public interface IDocumentService
    {
        Task<string> Insert(DocumentDto document);
    }
}