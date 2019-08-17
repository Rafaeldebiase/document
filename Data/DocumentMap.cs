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

            builder.HasKey(campo => campo.Code);

            builder.Property(field => field.Code)
                .HasColumnName("code")
                .ValueGeneratedNever()
                .HasColumnType("int");

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

            builder.Property(field => field.File)
                .IsRequired()
                .HasColumnName("file")
                .HasColumnType("MEDIUMBLOB");

            builder.Property(field => field.Delete)
                .HasColumnName("delete")
                .HasColumnType("bool");
        }
    }
}