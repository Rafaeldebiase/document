using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Enum;
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

        public async Task<string> Insert(DocumentDto documentDto)
        {
            var newDocumentModel = documentDto.ConvertToDocumentModel(documentDto);
                
            await _documentRepository.Insert(newDocumentModel);

            var responseDb = await _documentRepository.Save();

            if (responseDb == 1)
            {
                _logger.LogInformation($"Documento {newDocumentModel} inserido no banco.");
                return "Documento inserido no banco.";
            }
            else
            {
                _logger.LogError($"Erro: Documento {newDocumentModel} não foi inserido no banco.");
                return "Erro: Documento não foi inserido no banco.";
            }
        }

        public async Task Edit()
        {
            
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