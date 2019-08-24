using System.IO;
using System.Threading.Tasks;
using Document.Domain;
using Document.Interface.Repository;
using Document.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Document.Service
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<FileStreamResult> GetAsync(int id)
        {
            var file = await _fileRepository.GetAsync(id);

            MemoryStream memoryStream = new MemoryStream(file.Data);
            return new FileStreamResult(memoryStream, file.ContentType);
        }

        public async Task<int> insertAsync(IFormFile file, int id)
        {
            MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var fileModel = new FileModel(file.Name, memoryStream.ToArray(), file.ContentType, id);

            await _fileRepository.InsertAsync(fileModel);

            return await _fileRepository.Save();
        }
    }
}