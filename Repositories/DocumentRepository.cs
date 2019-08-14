using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Data;
using Document.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Document.Enum;
using Document.ObjectValue;

namespace Document.Repository
{
    public class DocumentRepository : BaseRepository<DocumentModel>
    {
        private readonly ConfigDataContext _context;

        public DocumentRepository(ConfigDataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<DocumentModel> GetId(Guid id) => 
            await _context.Documents.FindAsync(id);

        public async Task<DocumentModel> GetCode(Code code) =>
            await _context.Documents
                .Where(field => field.Code == code)
                .OrderBy(field => field.Title)
                .FirstOrDefaultAsync();

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

        public override async Task Insert(DocumentModel obj) => await _context.Documents.AddAsync(obj);

        public override void Edit(DocumentModel obj)
        {
            _context.Documents.Update(obj);
        }

        public override void Delete(DocumentModel obj)
        {
            _context.Documents.Update(obj);
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