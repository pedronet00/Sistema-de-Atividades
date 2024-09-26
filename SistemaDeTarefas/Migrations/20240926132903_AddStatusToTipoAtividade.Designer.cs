﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeTarefas.Data;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    [DbContext(typeof(SistemaTarefasDBContext))]
    [Migration("20240926132903_AddStatusToTipoAtividade")]
    partial class AddStatusToTipoAtividade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaDeTarefas.Models.AtividadeModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("dataAtividade")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("descricaoAtividade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("localAtividade")
                        .HasColumnType("int");

                    b.Property<int>("tipoAtividade")
                        .HasColumnType("int");

                    b.Property<string>("tituloAtividade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("localAtividade");

                    b.HasIndex("tipoAtividade");

                    b.ToTable("Atividade");
                });

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("localAtividade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("LocalAtividade");
                });

            modelBuilder.Entity("SistemaDeTarefas.Models.PostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("autorPost")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataPost")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("descricaoPost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("textoPost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("tituloPost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Post");
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("statusTipoAtividade")
                        .HasColumnType("int");

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

            modelBuilder.Entity("SistemaDeTarefas.Models.AtividadeModel", b =>
                {
                    b.HasOne("SistemaDeTarefas.Models.LocalAtividadeModel", "LocalAtividade")
                        .WithMany()
                        .HasForeignKey("localAtividade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeTarefas.Models.TipoAtividadeModel", "TipoAtividade")
                        .WithMany()
                        .HasForeignKey("tipoAtividade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalAtividade");

                    b.Navigation("TipoAtividade");
                });
#pragma warning restore 612, 618
        }
    }
}
