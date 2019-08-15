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

        public int Code { get; private set; }
        public string Title { get; private set; }
        public string Process { get; private set; }
        public Category Category { get; private set; }
        public byte[] Archive { get; private set; }
        public bool Delete { get; private set; }

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
    }
}