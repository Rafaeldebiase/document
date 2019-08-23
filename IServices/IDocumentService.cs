using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Microsoft.AspNetCore.JsonPatch;

namespace Document.Interface.Service
{
    public interface IDocumentService
    {
        Task<DocumentModel> GetCode(int code);
        IAsyncEnumerable<DocumentModel> GetTitle(string title);
        IAsyncEnumerable<DocumentModel> GetProcess(string process);
        IAsyncEnumerable<DocumentModel> GetCategory(int numberOfCategory);
        IAsyncEnumerable<DocumentModel> GetAll();
        Task<int> Insert(DocumentDto documentDto);
        Task<int> PacthAsync(JsonPatchDocument<DocumentDto> documentPatch, DocumentModel documentDto);
    }
}