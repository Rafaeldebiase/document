using Document.Data;
using Document.Interface.Repository;
using Document.Interface.Service;
using Document.Repository;
using Document.Service;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Document.Extension
{
    public static class DependencyInjectionSetupExtensions
    {

        public static void AddSetup( this IServiceCollection services)
        {
            services.AddDbContext<ConfigDataContext>();
            services.AddOData();

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>(); 
        }
    }
}