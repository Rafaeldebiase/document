using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Enum;
using Document.Interface.Repository;
using Document.Interface.Service;
using Microsoft.AspNetCore.JsonPatch;
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

        public async Task<DocumentModel> GetCode(int code) => 
            await _documentRepository.GetCode(code);

        public IAsyncEnumerable<DocumentModel> GetTitle(string title) => 
            _documentRepository.GetTitle(title);

        public IAsyncEnumerable<DocumentModel> GetProcess(string process) =>
            _documentRepository.GetProcess(process);
        
        public IAsyncEnumerable<DocumentModel> GetCategory(Category category) =>
            _documentRepository.GetCategory(category);
        
        public IAsyncEnumerable<DocumentModel> GetAll() =>
            _documentRepository.GetAll();

        public async Task<int> Insert(DocumentDto documentDto)
        {
            await _documentRepository.Insert(documentDto);

            return await _documentRepository.Save();
        }

        public async Task<int> PacthAsync(JsonPatchDocument<DocumentDto> documentPacth, DocumentModel documentModel)
        {
            _documentRepository.Patch(documentPacth, documentModel);
            return await _documentRepository.Save();
        }

    }
}