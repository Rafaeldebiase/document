using System.IO;
using Document.Interface.Service;
using Microsoft.AspNetCore.Http;

namespace Document.Service
{
    public class UploadService : IUploadService
    {
        public async System.Threading.Tasks.Task insertAsync(IFormFile file)
        {
            MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var x = memoryStream.ToArray();
        }
    }
}