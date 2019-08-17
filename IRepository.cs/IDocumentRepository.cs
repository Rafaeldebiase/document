using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Enum;
using Microsoft.AspNetCore.JsonPatch;

namespace Document.Interface.Repository
{
    public interface IDocumentRepository
    {
        Task<DocumentModel> GetCode(int code);
        IAsyncEnumerable<DocumentModel> GetTitle(string title);
        IAsyncEnumerable<DocumentModel> GetProcess(string process);
        IAsyncEnumerable<DocumentModel> GetCategory(Category category);
        IAsyncEnumerable<DocumentModel> GetAll();
        Task Insert(DocumentDto documentDto);
        void Patch(JsonPatchDocument<DocumentDto> documentDto, DocumentModel documentModel);
        Task<int> Save();
    }
}