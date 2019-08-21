
using System.Collections.Generic;
using Document.Dto;

namespace Document.Controller
{
    public partial class DocumentController
    {
        public IList<string> errorListDocumentDto = new List<string>();
        public bool DocumentDtoIsValid(DocumentDto documentDto)
        {

            if (documentDto.Code == 0)
            {
                errorListDocumentDto.Add($"O código não pode ser{documentDto.Code}");
            }

            if (string.IsNullOrEmpty(documentDto.Title))
            {
                errorListDocumentDto.Add($"O título não pode ser{documentDto.Title}");
            }

            if (string.IsNullOrEmpty(documentDto.Process))
            {
                errorListDocumentDto.Add($"O processo não pode ser{documentDto.Process}");
            }

            if (errorListDocumentDto.Count > 0)
                return false;

            return true;
        }
    }
}