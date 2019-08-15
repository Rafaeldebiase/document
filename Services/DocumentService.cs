using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Enum;
using Document.Extension;
using Document.Interface.Repository;
using Document.Interface.Service;
using Microsoft.AspNet.OData;
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

        public async Task<DocumentModel> GetId(int code)
        {
            return await _documentRepository.GetId(code);
        }

        public async Task<IList<DocumentModel>> GetTitle(string title)
        {
            return await _documentRepository.GetTitle(title);
        }
        public async Task<IList<DocumentModel>> GetProcess(string process)
        {
            return await _documentRepository.GetTitle(process);
        }
        public async Task<IList<DocumentModel>> GetCategory(Category category)
        {
            return await _documentRepository.GetCategory(category);
        }
        public async Task<IList<DocumentModel>> GetAll()
        {
            return await _documentRepository.GetAll();
        }

        public async Task<int> Insert(DocumentModel documentModel)
        {
            await _documentRepository.Insert(documentModel);

            return await _documentRepository.Save();
        }

        public async Task Edit(Delta<DocumentModel> document, DocumentModel documentModel)
        {
            _documentRepository.Edit(document, documentModel);
            

        }

        public async Task<string> Delete(int code)
        {   
            var document = _documentRepository.GetId(code).Result;
            
            var newDocumentModel = document.Deleted(document);

            _documentRepository.Delete(newDocumentModel);

            var responseDb = await _documentRepository.Save();
            
            if (responseDb == 1)
            {
                _logger.LogInformation($"Documento {newDocumentModel} deletado do banco.");
                return "Documento deletado do banco.";
            }
            else
            {
                _logger.LogError($"Erro: Documento {newDocumentModel} não foi deletado do banco.");
                return "Erro: Documento não foi deletado do banco.";
            }
        }

    }
}