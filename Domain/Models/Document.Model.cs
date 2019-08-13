using Document.Enum;
using Document.ObjectValue;

namespace Document.Domain
{
    public class Document
    {
        public Document(Code code, string title, string process, Category category, string archive)
        {
            Code = code;
            Title = title;
            Process = process;
            Category = category;
            Archive = archive;
        }

        public Code Code { get; private set; }
        public string Title { get; private set; }
        public string Process { get; private set; }
        public Category Category { get; private set; }
        public string Archive { get; private set; }
    }
}

