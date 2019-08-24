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

        public async Task<DocumentModelReturnDto> GetCode(int code)
        {
            var document = await _documentRepository.GetCode(code);

            return new DocumentModelReturnDto(document.Code, document.Title, document.Process,
                CategoryEnumToString(document.Category));
        }

        public IEnumerable<DocumentModelReturnDto> GetTitle(string title)
        {
            var documents = _documentRepository.GetTitle(title);

            return DocumentModelToDocumentModelReturnDto(documents);
        }

        public IEnumerable<DocumentModelReturnDto> GetProcess(string process)
        {
            var documents = _documentRepository.GetProcess(process);

            return DocumentModelToDocumentModelReturnDto(documents);
        }

        public IEnumerable<DocumentModelReturnDto> GetCategory(int numberOfCategory)
        {
            var category = (Category)numberOfCategory;

            var documents = _documentRepository.GetCategory(category);

            return DocumentModelToDocumentModelReturnDto(documents);

        }

        public IEnumerable<DocumentModelReturnDto> GetAll()
        {
            var documents = _documentRepository.GetAll();

            return DocumentModelToDocumentModelReturnDto(documents);

        }

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

        private IEnumerable<DocumentModelReturnDto> DocumentModelToDocumentModelReturnDto(IEnumerable<DocumentModel> documents)
        {
            IEnumerable<DocumentModelReturnDto> documentList = new List<DocumentModelReturnDto>();


            foreach (var item in documents)
            {
                var document = new DocumentModelReturnDto(item.Code, item.Title, item.Process,
                    CategoryEnumToString(item.Category));

                documentList.Append(document);
            }

            return documentList;
        }
        private string CategoryEnumToString(Category category)
        {
            switch (category)
            {
                case Category.RN1:
                    return "RN1";
                case Category.RN2:
                    return "RN2";
                case Category.RN3:
                    return "RN4";
                default:
                    return "RN5";
            }
        }
    }
}