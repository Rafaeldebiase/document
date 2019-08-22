using Document.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Document.Data
{
    public class FileMap : IEntityTypeConfiguration<FileModel>
    {
        public void Configure(EntityTypeBuilder<FileModel> builder)
        {
            builder.ToTable("File");

            builder.HasKey(field => field.Id);

            builder.Property(field => field.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");
            
            builder.Property(field => field.Name)
                .HasColumnName("name")
                .HasColumnType("LONGTEXT")
                .IsRequired();
            
            builder.Property(field => field.ContentType)
                .HasColumnName("content_type")
                .HasColumnType("varchar(300)");
            
            builder.HasOne(field => field.Document)
                .WithOne(field => field.File)
                .HasForeignKey<FileModel>(field => field.DocumentModelId);

            builder.Property(field => field.Data)
                .HasColumnName("data")
                .HasColumnType("LONGBLOB")
                .IsRequired();
        }
    }
}