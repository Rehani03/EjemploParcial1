﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrimerParcialEjemplo.DAL;

namespace PrimerParcialEjemplo.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200704001106_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("PrimerParcialEjemplo.Models.Empleado", b =>
                {
                    b.Property<int>("empleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("estado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.Property<int>("ocupacion")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("sueldo")
                        .HasColumnType("TEXT");

                    b.HasKey("empleadoId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("PrimerParcialEjemplo.Models.Usuario", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("contraseña")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("nivel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.HasKey("usuarioId");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
