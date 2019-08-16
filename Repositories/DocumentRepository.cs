using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Data;
using Document.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Document.Enum;
using Document.Interface.Repository;
using Microsoft.AspNet.OData;
using Document.Dto;

namespace Document.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ConfigDataContext _context;

        public DocumentRepository(ConfigDataContext context)
        {
            _context = context;
        }

        public async Task<DocumentModel> GetId(int code) =>
            await _context.Documents
                .FindAsync(code);

        public async Task<IList<DocumentModel>> GetTitle(string title) =>
            await _context.Documents
                .Where(field => field.Title.Contains(title))
                .OrderBy(field => field.Title)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IList<DocumentModel>> GetProcess(string process) =>
            await _context.Documents
                .Where(field => field.Process.Contains(process))
                .OrderBy(field => field.Title)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IList<DocumentModel>> GetCategory(Category category) =>
            await _context.Documents
                .Where(field => field.Category == category)
                .OrderBy(field => field.Title)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IList<DocumentModel>> GetAll() =>
            await _context.Documents
                .OrderBy(field => field.Title)
                .AsNoTracking()
                .ToListAsync();

        public async Task Insert(DocumentModel document)
        {
            try
            {
                await _context.Documents.AddAsync(document);
            }
            catch (System.InvalidOperationException e)
            {
                throw new Exception("erro: ", e);
            }
        }

        public void Edit(Delta<DocumentModel> deltaDocument, DocumentModel documentModel)
        {
            deltaDocument.Patch(documentModel);
        }

        public void Delete(DocumentModel document)
        {
            _context.Documents.Update(document);
        }

        public async Task<int> Save()
        {
            try
            {
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Erro: ", e);
            }
            catch (ObjectDisposedException err)
            {
                throw new Exception("Erro: ", err);
            }
        }
    }
}