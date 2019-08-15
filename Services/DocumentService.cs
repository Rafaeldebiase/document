using Document.Domain;
using Document.Dto;
using Document.Interface.Repository;
using Document.Interface.Service;
using Microsoft.Extensions.Logging;

namespace Document.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(IDocumentRepository documentRepository, ILogger<DocumentService> logger)
        {
            _documentRepository = documentRepository;
            _logger = logger;
        }

        public void Insert(DocumentDto document)
        {
            var newDocument = new DocumentModel(document.Code, document.Title, document.Process,
                document.Category, document.Archive, document.Delete); 
                
            _documentRepository.Insert(newDocument);
            var x = _documentRepository.Save();
        }
    }
}