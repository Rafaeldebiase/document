using Document.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Document.Data
{
    public class DocumentMap : IEntityTypeConfiguration<DocumentModel>
    {
        public void Configure(EntityTypeBuilder<DocumentModel> builder)
        {
            builder.ToTable("Document");

            builder.HasKey(campo => campo.Id);
            
            builder.OwnsOne(campo => campo.Code, code =>{
                code.Property(campo => campo.Number)
                    .IsRequired()
                    .HasColumnName("Code")
                    .HasColumnType("int");
            });

            builder.Property(campo => campo.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasColumnType("varchar(200)");

            builder.Property(campo => campo.Process)
                .IsRequired()
                .HasColumnName("process")
                .HasColumnType("varchar(200)");

            builder.Property(campo => campo.Category)
                .IsRequired()
                .HasColumnName("category")
                .HasColumnType("varchar(200)");

            builder.Property(campo => campo.Archive)
                .IsRequired()
                .HasColumnName("archive")
                .HasColumnType("binary(16)");
        }
    }
}