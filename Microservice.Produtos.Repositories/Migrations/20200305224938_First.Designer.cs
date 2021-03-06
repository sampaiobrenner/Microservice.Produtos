﻿// <auto-generated />
using System;
using Microservice.Produtos.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Microservice.Produtos.Repositories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200305224938_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microservice.Produtos.Entities.Entities.CategoriaDoProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaDoProduto");
                });

            modelBuilder.Entity("Microservice.Produtos.Entities.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriaDoProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoDeCusto")
                        .HasColumnName("PrecoDeCusto")
                        .HasColumnType("decimal(5,3)");

                    b.Property<decimal>("PrecoDeVenda")
                        .HasColumnName("PrecoDeVenda")
                        .HasColumnType("decimal(5,3)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaDoProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Microservice.Produtos.Entities.Entities.Produto", b =>
                {
                    b.HasOne("Microservice.Produtos.Entities.Entities.CategoriaDoProduto", "CategoriaDoProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaDoProdutoId");
                });
#pragma warning restore 612, 618
        }
    }
}
