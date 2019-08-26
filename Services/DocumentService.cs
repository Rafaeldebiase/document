using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Enuns;
using Document.Interface.Repository;
using Document.Interface.Service;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System.Linq;

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

        public async Task<DocumentModelReturnDto> GetCode(int code) => 
            await _documentRepository.GetCode(code);

        public async Task<bool> DocumentExist(int code) 
        {
            var document = await _documentRepository.GetCode(code);

            if (document != null)
                return true;
            
            return false;
        }

        public IEnumerable<DocumentModelReturnDto> GetTitle(string title) =>
            _documentRepository.GetTitle(title);

        public IEnumerable<DocumentModelReturnDto> GetProcess(string process) =>
            _documentRepository.GetProcess(process);

        public IEnumerable<DocumentModelReturnDto> GetCategory(int numberOfCategory)
        {
            var category = (Category)numberOfCategory;

            return _documentRepository.GetCategory(category);

        }

        public IEnumerable<DocumentModelReturnDto> GetAll() => 
            _documentRepository.GetAll();

        public async Task<int> Insert(DocumentDto documentDto)
        {
            await _documentRepository.Insert(documentDto);

            return await _documentRepository.Save();
        }

        public async Task<int> PacthAsync(JsonPatchDocument<DocumentDto> documentPacth, int code)
        {
            _documentRepository.Patch(documentPacth, code);
            return await _documentRepository.Save();
        }
    }
}