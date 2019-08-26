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
        Task<DocumentModelReturnDto> GetCode(int code);
        IEnumerable<DocumentModelReturnDto> GetTitle(string title);
        IEnumerable<DocumentModelReturnDto> GetProcess(string process);
        IEnumerable<DocumentModelReturnDto> GetCategory(Category category);
        IEnumerable<DocumentModelReturnDto> GetAll();
        Task Insert(DocumentDto documentDto);
        void Patch(JsonPatchDocument<DocumentDto> documentDto, int code);
        Task<int> Save();
    }
}