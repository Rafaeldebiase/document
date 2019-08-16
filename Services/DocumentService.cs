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

        public async Task<DocumentModel> GetId(int code) => 
            await _documentRepository.GetId(code);

        public async Task<IList<DocumentModel>> GetTitle(string title) => 
            await _documentRepository.GetTitle(title);

        public async Task<IList<DocumentModel>> GetProcess(string process) =>
        await _documentRepository.GetTitle(process);
        
        public async Task<IList<DocumentModel>> GetCategory(Category category) =>
        await _documentRepository.GetCategory(category);
        
        public async Task<IList<DocumentModel>> GetAll() =>
            await _documentRepository.GetAll();

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