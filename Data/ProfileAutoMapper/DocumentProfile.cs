using AutoMapper;
using Document.Domain;
using Document.Dto;

namespace Document.Data.ProfileAutoMapper
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentModel, DocumentDto>();
        }
    }
}