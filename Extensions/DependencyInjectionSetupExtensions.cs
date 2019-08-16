using AutoMapper;
using Document.Data;
using Document.Data.ProfileAutoMapper;
using Document.Interface.Repository;
using Document.Interface.Service;
using Document.Repository;
using Document.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Document.Extension
{
    public static class DependencyInjectionSetupExtensions
    {

        public static void AddSetup( this IServiceCollection services)
        {
            services.AddDbContext<ConfigDataContext>();

            services.AddAutoMapper(typeof(DocumentProfile));

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>(); 
        }
    }
}