
namespace Document.Domain
{
    public class FileModel
    {
        protected FileModel()
        {
            
        }
        public FileModel(string name, byte[] data, string contentType, int documentModelId)
        {
            Name = name;
            Data = data;
            ContentType = contentType;
            DocumentModelId = documentModelId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set;}
        public string ContentType { get; set; } 
        public int DocumentModelId { get; set;}
        public DocumentModel Document { get; set; }
    }
}