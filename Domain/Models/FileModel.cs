using System;

namespace Document.Domain
{
    public class FileModel
    {
        protected FileModel()
        {
            
        }
        public FileModel(int id, string name, byte[] data, string contentType)
        {
            Id = id;
            Name = name;
            Data = data;
            ContentType = contentType;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public byte[] Data { get; private set;}
        public string ContentType { get; private set; } 
        public DocumentModel Document { get; set; }
    }
}