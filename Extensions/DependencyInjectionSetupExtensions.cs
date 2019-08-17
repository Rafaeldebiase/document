using System;
using AutoMapper;
using Document.Data;
using Document.Data.ProfileAutoMapper;
using Document.Interface.Repository;
using Document.Interface.Service;
using Document.Repository;
using Document.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace Document.Extension
{
    public static class DependencyInjectionSetupExtensions
    {

        public static void AddSetup(this IServiceCollection services)
        {
            services.AddDbContext<ConfigDataContext>();

            services.AddAutoMapper(typeof(DocumentProfile));
            services.AddHealthChecks()
                .AddMySql("Server=localhost;User Id=rafael;Password=rafael123456;Database=documentdb;", "Banco MySql");
            services.AddHealthChecksUI();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Document Api",
                    Description = "Gestão de documentos",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael de Biase",
                        Email = "rafaelvitaldebiase@gmail.com",
                        Url = new Uri("https://linkedin.com/in/rafaeldebiase/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>();
        }
    }
}