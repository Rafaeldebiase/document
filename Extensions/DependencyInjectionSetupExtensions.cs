using Document.Data;
using Document.Interface.Repository;
using Document.Interface.Service;
using Document.Repository;
using Document.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Document.Extension
{
    public static class DependencyInjectionSetupExtensions
    {

        public static void AddSetup( this IServiceCollection services)
        {
            services.AddSingleton<ConfigDataContext>();

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>(); 
        }
    }
}