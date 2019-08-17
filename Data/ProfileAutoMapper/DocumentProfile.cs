using AutoMapper;
using Document.Domain;
using Document.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace Document.Data.ProfileAutoMapper
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentDto, DocumentModel>();
            CreateMap<DocumentModel, DocumentDto>();
        }
    }
}