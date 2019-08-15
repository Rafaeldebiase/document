using Document.Domain;
using Document.Enum;
using System;
using System.Collections;
using System.Linq;

namespace Document.Dto
{
    public class DocumentDto
    {
        public DocumentDto(int code, string title, string process, int category, bool delete)
        {
            Code = code;
            Title = title;
            Process = process;
            Category = ReceiveIntAndReturnCategory(category);
            Archive = new byte[0];
            Delete = delete;
        }

        public int Code { get; set; }
        public string Title { get; set; }
        public string Process { get; set; }
        public Category Category { get; set; }
        public byte[] Archive { get; set; }
        public bool Delete { get; set; }

        private Category ReceiveIntAndReturnCategory(int category)
        {
            if ((int)Category.RN1 == category)
            {
                return Category.RN1;
            }
            if ((int)Category.RN2 == category)
            {
                return Category.RN2;
            }
            if ((int)Category.RN3 == category)
            {
                return Category.RN3;
            }
            if ((int)Category.RN4 == category)
            {
                return Category.RN4;
            }
            else
            {
                return Category.RN5;
            }
        }

        public DocumentModel ConvertToDocumentModel(DocumentDto documentDto)
        {
            return new DocumentModel(documentDto.Code, documentDto.Title, documentDto.Process, 
                documentDto.Category, documentDto.Archive, documentDto.Delete);
        }
    }
}