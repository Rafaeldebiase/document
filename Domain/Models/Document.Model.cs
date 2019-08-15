using Document.Dto;
using Document.Enum;


namespace Document.Domain
{
    public class DocumentModel
    {
        public DocumentModel(bool delete = false)
        {
            Delete = delete;
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

        public DocumentDto ConvertToDocumentDto(DocumentModel document)
        {
            return new DocumentDto(document.Code, document.Title, document.Process,
                (int)document.Category, document.Delete);
        }

        public DocumentModel Deleted(DocumentModel documentModel)
        {
            var documentDto = documentModel.ConvertToDocumentDto(documentModel);

            documentDto.Delete = true;

            return new DocumentModel(documentDto.Code, documentDto.Title, documentDto.Process,
                documentDto.Category, documentDto.Archive, documentDto.Delete);
        }
    }
}

