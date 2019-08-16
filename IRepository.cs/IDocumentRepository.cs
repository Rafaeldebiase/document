using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Enum;
using Document.ObjectValue;
using Microsoft.AspNet.OData;

namespace Document.Interface.Repository
{
    public interface IDocumentRepository
    {
        Task<DocumentModel> GetId(int code);
        Task<IList<DocumentModel>> GetTitle(string title);
        Task<IList<DocumentModel>> GetProcess(string process);
        Task<IList<DocumentModel>> GetCategory(Category category);
        Task<IList<DocumentModel>> GetAll();
        Task Insert(DocumentModel obj);
        void Edit(Delta<DocumentModel> document, DocumentModel documentModel);
        void Delete(DocumentModel obj);
        Task<int> Save();
    }
}