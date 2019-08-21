using System;
using Document.Enum;

namespace Document.Domain
{
    public class DocumentModel
    {

        protected DocumentModel()
        {

        }

        public DocumentModel(int code, string title, string process, Category category,
            bool delete)
        {
            Code = code;
            Title = title;
            Process = process;
            Category = category;
            Delete = delete;
        }

        public int Code { get; private set; }
        public string Title { get; private set; }
        public string Process { get; private set; }
        public Category Category { get; private set; }
        public bool Delete { get; private set; }
        public FileModel File { get; set; }
    }
}

