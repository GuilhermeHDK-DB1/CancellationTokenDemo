﻿// <auto-generated />
using CancellationTokenDemo.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CancellationTokenDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CancellationTokenDemo.Entities.Tabela1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Tabela1", (string)null);
                });

            modelBuilder.Entity("CancellationTokenDemo.Entities.Tabela2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("QuantidadeDeContas")
                        .HasColumnType("int")
                        .HasColumnName("quantidade_conta");

                    b.HasKey("Id");

                    b.ToTable("Tabela2", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}