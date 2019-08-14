using System;
using Document.Data;
using Document.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Document.Data
{
    public partial class ConfigDataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ConfigDataContext()
        {
        }

        public ConfigDataContext(DbContextOptions<ConfigDataContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<DocumentModel> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=rafael;Password=rafael123456;Database=documentdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DocumentMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
