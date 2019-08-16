using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Enum;
using Microsoft.AspNetCore.JsonPatch;

namespace Document.Interface.Service
{
    public interface IDocumentService
    {
        Task<DocumentModel> GetId(int code);
        Task<IList<DocumentModel>> GetTitle(string title);
        Task<IList<DocumentModel>> GetProcess(string process);
        Task<IList<DocumentModel>> GetCategory(Category category);
        Task<IList<DocumentModel>> GetAll();
        Task<int> Insert(DocumentDto documentDto);
        Task<int> PacthAsync(JsonPatchDocument<DocumentDto> documentPatch, DocumentModel documentDto);
    }
}