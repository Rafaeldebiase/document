using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Data;
using Document.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Document.Enum;
using Document.Interface.Repository;
using AutoMapper;
using Document.Dto;
using Microsoft.AspNetCore.JsonPatch;

namespace Document.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ConfigDataContext _context;
        private readonly IMapper _mapper;

        public DocumentRepository(ConfigDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task Insert(DocumentDto documentDto)
        {
            try
            {
                DocumentModel documentModel = _mapper.Map<DocumentModel>(documentDto);

                await _context.Documents.AddAsync(documentModel);
            }
            catch (System.InvalidOperationException e)
            {
                throw new Exception("erro: ", e);
            }
        }

        public void Patch(JsonPatchDocument<DocumentDto> documentPatch, DocumentModel documentModel)
        {
            DocumentDto documentDto = _mapper.Map<DocumentDto>(documentModel);

            documentPatch.ApplyTo(documentDto);

            _mapper.Map(documentDto, documentModel);

            _context.Update(documentModel);
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