using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Data;
using Document.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Document.Enuns;
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

        public async Task<DocumentModelReturnDto> GetCode(int code) =>
            await _context.Documents
                .Where(field => field.Delete == false && field.Code == code)
                .Select(field => new DocumentModelReturnDto(
                    field.Code, field.Title, field.Process, CategoryEnumToString(field.Category), 
                    field.File.Name))
                .FirstOrDefaultAsync();

        public IEnumerable<DocumentModelReturnDto> GetTitle(string title) =>
            _context.Documents
                .Where(field => field.Title.Contains(title) && field.Delete == false)
                .Select(field => new DocumentModelReturnDto(
                    field.Code, field.Title, field.Process, CategoryEnumToString(field.Category), 
                    field.File.Name))
                .OrderBy(field => field.Title)
                .AsNoTracking()
                .AsEnumerable();

        public IEnumerable<DocumentModelReturnDto> GetProcess(string process) =>
            _context.Documents
                .Where(field => field.Process.Contains(process) && field.Delete == false)
                .Select(field => new DocumentModelReturnDto(
                    field.Code, field.Title, field.Process, CategoryEnumToString(field.Category), 
                    field.File.Name))
                .OrderBy(field => field.Title)
                .AsNoTracking()
                .AsEnumerable();

        public IEnumerable<DocumentModelReturnDto> GetCategory(Category category) =>
            _context.Documents
                .Where(field => field.Category == category && field.Delete == false)
                .Select(field => new DocumentModelReturnDto(
                    field.Code, field.Title, field.Process, CategoryEnumToString(field.Category), 
                    field.File.Name))
                .OrderBy(field => field.Title)
                .AsNoTracking()
                .AsEnumerable();

        public IEnumerable<DocumentModelReturnDto> GetAll() =>
            _context.Documents
                .Where(field => field.Delete == false)
                .Select(field => new DocumentModelReturnDto(
                    field.Code, field.Title, field.Process, CategoryEnumToString(field.Category), 
                    field.File.Name))
                .OrderBy(field => field.Title)
                .AsNoTracking()
                .AsEnumerable();

        public async Task Insert(DocumentDto documentDto)
        {
            try
            {
                DocumentModel documentModel = _mapper.Map<DocumentModel>(documentDto);

                await _context.Documents.AddAsync(documentModel);
            }
            catch (AutoMapperMappingException e)
            {
                throw new Exception("erro: ", e);
            }
        }

        public void Patch(JsonPatchDocument<DocumentDto> documentPatch, int code)
        {
            try
            {
                var documentModel = GetCode(code).Result;

                DocumentDto documentDto = _mapper.Map<DocumentDto>(documentModel);

                documentPatch.ApplyTo(documentDto);

                _mapper.Map(documentDto, documentModel);

                _context.Update(documentModel);
            }
            catch (AutoMapperMappingException e)
            {

                throw new Exception("erro: ", e);            
            }

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

        private string CategoryEnumToString(Category category)
        {
            switch (category)
            {
                case Category.RN1:
                    return "RN1";
                case Category.RN2:
                    return "RN2";
                case Category.RN3:
                    return "RN4";
                default:
                    return "RN5";
            }
        }
    }
}