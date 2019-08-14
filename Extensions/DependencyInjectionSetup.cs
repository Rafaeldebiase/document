using Document.Data;
using Document.Interface.Repository;
using Document.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Document.Extension
{
    public static class DependencyInjectionSetup
    {
        public static void Setup( this IServiceCollection services)
        {
            services.AddScoped<ConfigDataContext>();

            services.AddTransient<IDocumentRepository, DocumentRepository>();
        }
    }
}