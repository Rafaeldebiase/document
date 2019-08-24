using System;
using System.Threading.Tasks;
using AutoMapper;
using Document.Data;
using Document.Domain;
using Document.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Document.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly ConfigDataContext _context;
        private readonly IMapper _mapper;

        public FileRepository(ConfigDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FileModel> GetAsync(int id) => 
            await _context.Files.FirstOrDefaultAsync(field => field.DocumentModelId == id);

        public async Task InsertAsync(FileModel file)
        {
            await _context.Files.AddAsync(file);
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