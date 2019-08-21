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

            builder.HasKey(field => field.Code);

            builder.Property(field => field.Code)
                .HasColumnName("code")
                .ValueGeneratedNever()
                .HasColumnType("int");

            builder.Property(field => field.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasColumnType("varchar(200)");

            builder.Property(field => field.Process)
                .IsRequired()
                .HasColumnName("process")
                .HasColumnType("varchar(200)");

            builder.Property(field => field.Category)
                .IsRequired()
                .HasColumnName("category")
                .HasColumnType("varchar(200)");

            builder.HasOne(field => field.File)
                .WithOne(field => field.Document)
                .HasForeignKey<FileModel>(field => field.Id)
                .HasPrincipalKey<DocumentModel>(field => field.FileId);

            builder.Property(field => field.Delete)
                .HasColumnName("delete")
                .HasColumnType("bool");
        }
    }
}