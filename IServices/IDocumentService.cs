using Document.Dto;

namespace Document.Interface.Service
{
    public interface IDocumentService
    {
        void Insert(DocumentDto document);
    }
}