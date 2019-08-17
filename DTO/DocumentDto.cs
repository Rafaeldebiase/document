using Document.Domain;
using Document.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Document.Dto
{
    public class DocumentDto
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Process { get; set; }
        public int Category { get; set; }
        public byte[] File { get; set; }
        public IFormFile FormFile { get; set; }
        public bool Delete { get; set; }

        private async Task<byte[]> UploadAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        // private Category ReceiveIntAndReturnCategory(int category)
        // {
        //     if ((int)Category.RN1 == category)
        //     {
        //         return Category.RN1;
        //     }
        //     if ((int)Category.RN2 == category)
        //     {
        //         return Category.RN2;
        //     }
        //     if ((int)Category.RN3 == category)
        //     {
        //         return Category.RN3;
        //     }
        //     if ((int)Category.RN4 == category)
        //     {
        //         return Category.RN4;
        //     }
        //     else
        //     {
        //         return Category.RN5;
        //     }
        // }

        // public DocumentModel ConvertToDocumentModel(DocumentDto documentDto)
        // {
        //     return new DocumentModel(documentDto.Code, documentDto.Title, documentDto.Process, 
        //         documentDto.Category, documentDto.Archive, documentDto.Delete);
        // }
    }
}