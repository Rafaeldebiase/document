using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Enuns;
using Microsoft.AspNetCore.JsonPatch;

namespace Document.Interface.Repository
{
    public interface IDocumentRepository
    {
        Task<DocumentModel> GetCode(int code);
        IEnumerable<DocumentModel> GetTitle(string title);
        IEnumerable<DocumentModel> GetProcess(string process);
        IEnumerable<DocumentModel> GetCategory(Category category);
        IEnumerable<DocumentModel> GetAll();
        Task Insert(DocumentDto documentDto);
        void Patch(JsonPatchDocument<DocumentDto> documentDto, int code);
        Task<int> Save();
    }
}