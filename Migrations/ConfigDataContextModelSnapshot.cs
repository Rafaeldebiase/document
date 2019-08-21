﻿// <auto-generated />
using System;
using Document.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace document.Migrations
{
    [DbContext(typeof(ConfigDataContext))]
    partial class ConfigDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Document.Domain.DocumentModel", b =>
                {
                    b.Property<int>("Code")
                        .HasColumnName("code")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnName("category")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Delete")
                        .HasColumnName("delete")
                        .HasColumnType("bool");

                    b.Property<Guid>("FileId");

                    b.Property<string>("Process")
                        .IsRequired()
                        .HasColumnName("process")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Code");

                    b.HasAlternateKey("FileId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Document.Domain.FileModel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("code")
                        .HasColumnType("uuid");

                    b.Property<string>("ContentType")
                        .HasColumnName("content_type")
                        .HasColumnType("varchar(300)");

                    b.Property<byte[]>("Data");

                    b.Property<int>("DocumentId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("LONGTEXT");

                    b.HasKey("Id");

                    b.ToTable("File");
                });

            modelBuilder.Entity("Document.Domain.DocumentModel", b =>
                {
                    b.HasOne("Document.Domain.FileModel", "File")
                        .WithOne("Document")
                        .HasForeignKey("Document.Domain.DocumentModel", "Code")
                        .HasPrincipalKey("Document.Domain.FileModel", "DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
