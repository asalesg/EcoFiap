﻿// <auto-generated />
using System;
using EcoFiap.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace EcoFiap.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230411135150_Other")]
    partial class Other
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcoFiap.Models.AvaliacaoModel", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvaliacaoId"));

                    b.Property<string>("Comentario")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Nota")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("AvaliacaoId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("EcoFiap.Models.ColetaModel", b =>
                {
                    b.Property<int>("ColetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColetaId"));

                    b.Property<DateTime>("DataHoraAgendada")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Endereco")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Tipo")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ColetaId");

                    b.ToTable("Coleta");
                });

            modelBuilder.Entity("EcoFiap.Models.ColetorModel", b =>
                {
                    b.Property<int>("ColetorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("COLETORID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColetorId"));

                    b.Property<int?>("AvaliacaoModelAvaliacaoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("ColetaModelColetaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ENDERECOCOLETOR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOMECOLETOR");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TELEFONECOLETOR");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("EMAILCOLETOR");

                    b.HasKey("ColetorId");

                    b.HasIndex("AvaliacaoModelAvaliacaoId");

                    b.HasIndex("ColetaModelColetaId");

                    b.ToTable("COLETOR");
                });

            modelBuilder.Entity("EcoFiap.Models.GeolocalizacaoModel", b =>
                {
                    b.Property<int>("LocalizaçãoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocalizaçãoId"));

                    b.Property<int?>("ColetorId1")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Latitude")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Longitude")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UsuarioId1")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("LocalizaçãoId");

                    b.HasIndex("ColetorId1");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("Geolocalizacao");
                });

            modelBuilder.Entity("EcoFiap.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("USUARIOID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<int?>("AvaliacaoModelAvaliacaoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("ColetaModelColetaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("ENDERECOUSUARIO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOMEUSUARIO");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TELEFONEUSUARIO");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("EMAILSUARIO");

                    b.HasKey("UsuarioId");

                    b.HasIndex("AvaliacaoModelAvaliacaoId");

                    b.HasIndex("ColetaModelColetaId");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("EcoFiap.Models.ColetorModel", b =>
                {
                    b.HasOne("EcoFiap.Models.AvaliacaoModel", null)
                        .WithMany("Coletors")
                        .HasForeignKey("AvaliacaoModelAvaliacaoId");

                    b.HasOne("EcoFiap.Models.ColetaModel", null)
                        .WithMany("Coletors")
                        .HasForeignKey("ColetaModelColetaId");
                });

            modelBuilder.Entity("EcoFiap.Models.GeolocalizacaoModel", b =>
                {
                    b.HasOne("EcoFiap.Models.ColetorModel", "ColetorId")
                        .WithMany()
                        .HasForeignKey("ColetorId1");

                    b.HasOne("EcoFiap.Models.UsuarioModel", "UsuarioId")
                        .WithMany()
                        .HasForeignKey("UsuarioId1");

                    b.Navigation("ColetorId");

                    b.Navigation("UsuarioId");
                });

            modelBuilder.Entity("EcoFiap.Models.UsuarioModel", b =>
                {
                    b.HasOne("EcoFiap.Models.AvaliacaoModel", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("AvaliacaoModelAvaliacaoId");

                    b.HasOne("EcoFiap.Models.ColetaModel", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("ColetaModelColetaId");
                });

            modelBuilder.Entity("EcoFiap.Models.AvaliacaoModel", b =>
                {
                    b.Navigation("Coletors");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("EcoFiap.Models.ColetaModel", b =>
                {
                    b.Navigation("Coletors");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}