﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeTarefas.Data;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    [DbContext(typeof(SistemaTarefasDBContext))]
    [Migration("20240920220052_LocalAtividade")]
    partial class LocalAtividade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaDeTarefas.Models.LivroModel", b =>
                {
                    b.Property<int>("idLivro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("autorLivro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("editoraLivro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nomeLivro")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("quantidadePaginasLivro")
                        .HasColumnType("int");

                    b.Property<int>("statusLivro")
                        .HasColumnType("int");

                    b.HasKey("idLivro");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("SistemaDeTarefas.Models.LocalAtividadeModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("localAtividade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("LocalAtividade");
                });

            modelBuilder.Entity("SistemaDeTarefas.Models.TarefaModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("SistemaDeTarefas.Models.TipoAtividadeModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("tipoAtividade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("TipoAtividade");
                });

            modelBuilder.Entity("SistemaDeTarefas.Models.UsuarioModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
