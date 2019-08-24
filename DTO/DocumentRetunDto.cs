namespace Document.Dto
{
    public class DocumentModelReturnDto
    {
        public DocumentModelReturnDto(int code, string title, string process, string category)
        {
            Code = code;
            Title = title;
            Process = process;
            Category = category;
        }

        public int Code { get; private set; }
        public string Title { get; private set; }
        public string Process { get; private set; }
        public string Category { get; private set; }
    }
}