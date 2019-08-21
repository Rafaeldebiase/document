using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Document.Interface.Service
{
    public interface IUploadService
    {
        Task<int> insertAsync(IFormFile file, int id);
        Task<FileStreamResult> GetAsync(int id);
    }
}