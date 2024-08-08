﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Entidades.Articulo", b =>
                {
                    b.Property<int>("Sku")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sku"));

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("Clase")
                        .HasColumnType("int");

                    b.Property<int?>("Departamento")
                        .HasColumnType("int");

                    b.Property<bool>("Descontinuado")
                        .HasColumnType("bit");

                    b.Property<int?>("Familia")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClase")
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<int>("IdFamilia")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Sku");

                    b.HasIndex("Clase");

                    b.HasIndex("Departamento");

                    b.HasIndex("Familia");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Models.Entidades.Clase", b =>
                {
                    b.Property<int>("IdClase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClase"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdClase");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("Models.Entidades.Departamento", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamento"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDepartamento");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Models.Entidades.Familia", b =>
                {
                    b.Property<int>("IdFamilia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFamilia"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdFamilia");

                    b.ToTable("Familias");
                });

            modelBuilder.Entity("Models.Entidades.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUsuario"));

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Models.Entidades.Articulo", b =>
                {
                    b.HasOne("Models.Entidades.Clase", "clase")
                        .WithMany()
                        .HasForeignKey("Clase");

                    b.HasOne("Models.Entidades.Departamento", "departamento")
                        .WithMany()
                        .HasForeignKey("Departamento");

                    b.HasOne("Models.Entidades.Familia", "familia")
                        .WithMany()
                        .HasForeignKey("Familia");

                    b.Navigation("clase");

                    b.Navigation("departamento");

                    b.Navigation("familia");
                });
#pragma warning restore 612, 618
        }
    }
}
