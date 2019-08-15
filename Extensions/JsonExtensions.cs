using Document.Dto;
using Newtonsoft.Json.Linq;

namespace Document.Extension
{
    public static class JsonExtension
    {
        public static DocumentDto DeserializesToDocumentDto(this JObject jObject)
        {
            return jObject.ToObject<DocumentDto>();
        }
    } 
}