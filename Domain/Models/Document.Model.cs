using System;
using System.ComponentModel.DataAnnotations;
using Document.Enum;
using Document.ObjectValue;

namespace Document.Domain
{
    public class DocumentModel
    {
        public DocumentModel()
        {
            
        }

        public DocumentModel(int code, string title, string process, Category category, byte[] archive, 
            bool delete)
        {
            Code = code;
            Title = title;
            Process = process;
            Category = category;
            Archive = archive;
            Delete = delete;
        }

        public int Code { get; private set; }
        public string Title { get; private set; }
        public string Process { get; private set; }
        public Category Category { get; private set; }
        public byte[] Archive { get; private set; }
        public bool Delete { get; private set; }
    }
}

