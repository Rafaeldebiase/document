using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Microsoft.AspNetCore.JsonPatch;

namespace Document.Interface.Service
{
    public interface IDocumentService
    {
        Task<DocumentModelReturnDto> GetCode(int code);
        IEnumerable<DocumentModelReturnDto> GetTitle(string title);
        IEnumerable<DocumentModelReturnDto> GetProcess(string process);
        IEnumerable<DocumentModelReturnDto> GetCategory(int numberOfCategory);
        IEnumerable<DocumentModelReturnDto> GetAll();
        Task<int> Insert(DocumentDto documentDto);
        Task<int> PacthAsync(JsonPatchDocument<DocumentDto> documentPatch, int code);
        Task<bool> DocumentExist(int code);
    }
}