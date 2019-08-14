﻿// <auto-generated />
using System;
using Document.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace document.Migrations
{
    [DbContext(typeof(ConfigDataContext))]
    [Migration("20190814154640_define_code_como_primary_key")]
    partial class define_code_como_primary_key
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Document.Domain.DocumentModel", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Archive")
                        .IsRequired()
                        .HasColumnName("archive")
                        .HasColumnType("binary(16)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnName("category")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Delete")
                        .HasColumnName("delete")
                        .HasColumnType("bool");

                    b.Property<string>("Process")
                        .IsRequired()
                        .HasColumnName("process")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Code");

                    b.ToTable("Document");
                });
#pragma warning restore 612, 618
        }
    }
}
