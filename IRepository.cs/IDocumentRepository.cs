using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Enum;
using Document.ObjectValue;

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
        void Edit(DocumentModel obj);
        void Delete(DocumentModel obj);
        Task<int> Save();
    }
}