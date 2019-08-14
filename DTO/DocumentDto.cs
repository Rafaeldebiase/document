using Document.Enum;
using System.Linq;

namespace Document.Dto
{
    public class DocumentDto
    {
        public DocumentDto(int code, string title, string process, int category, 
            byte[] archive, bool delete)
        {
            Code = code;
            Title = title;
            Process = process;
            Category = ReceiveIntAndReturnCategory(category);
            Archive = archive;
            Delete = delete;
        }

        public int Code { get; private set; }
        public string Title { get; private set; }
        public string Process { get; private set; }        
        public Category Category { get; private set; }
        public byte[] Archive { get; private set; }
        public bool Delete { get; private set; }

        private Category ReceiveIntAndReturnCategory(int category)
        {
            var x = Category.ToObject(typeof(Category), (int)Category.RN1);

            int y = (int)Category.
            

            
        }
    }
}