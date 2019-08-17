using Document.Enum;

namespace Document.Domain
{
    public class DocumentModel
    {

        public DocumentModel()
        {

        }

        public DocumentModel(int code, string title, string process, Category category,
            bool delete, byte[] file)
        {
            Code = code;
            Title = title;
            Process = process;
            Category = category;
            Delete = delete;
            File = file;
        }

        public int Code { get; private set; }
        public string Title { get; private set; }
        public string Process { get; private set; }
        public Category Category { get; private set; }
        public bool Delete { get; private set; }
        public byte[] File { get; private set; }
    }
}

