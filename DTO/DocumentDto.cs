using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Document.Dto
{
    public class DocumentDto
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Process { get; set; }
        public int Category { get; set; }
        public bool Delete { get; set; }
    }
}