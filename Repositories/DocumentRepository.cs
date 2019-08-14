using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Data;
using Document.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Document.Enum;
using Document.ObjectValue;
using Document.Interface.Repository;

namespace Document.Repository
{
    public class DocumentRepository : BaseRepository<DocumentModel>, IDocumentRepository
    {
        private readonly ConfigDataContext _context;

        public DocumentRepository(ConfigDataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<DocumentModel> GetId(int code) => 
            await _context.Documents.FindAsync(code);

        public async Task<IList<DocumentModel>> GetTitle(string title) =>
            await _context.Documents
                .Where(field => field.Title.Contains(title))
                .OrderBy(field => field.Title)
                .ToListAsync();
        
        public async Task<IList<DocumentModel>> GetProcess(string process) =>
            await _context.Documents
                .Where(field => field.Process.Contains(process))
                .OrderBy(field => field.Title)
                .ToListAsync();

        public async Task<IList<DocumentModel>> GetCategory(Category category) => 
            await _context.Documents
                .Where(field => field.Category == category)
                .OrderBy(field => field.Title)
                .ToListAsync();

        public override async Task<IList<DocumentModel>> GetAll() =>
            await _context.Documents
                .OrderBy(field => field.Title)
                .ToListAsync();

        public override async Task Insert(DocumentModel document) => await _context.Documents.AddAsync(document);

        public override void Edit(DocumentModel document)
        {
            _context.Documents.Update(document);
        }

        public override void Delete(DocumentModel document)
        {
            _context.Documents.Update(document);
        }

        public override async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                
                throw;
            }
        }
    }
}