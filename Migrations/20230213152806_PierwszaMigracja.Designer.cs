﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sklep_muzyczny.Data;

#nullable disable

namespace Sklep_muzyczny.Migrations
{
    [DbContext(typeof(Sklep_muzycznyContext))]
    [Migration("20230213152806_PierwszaMigracja")]
    partial class PierwszaMigracja
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sklep_muzyczny.Models.Kategoria", b =>
                {
                    b.Property<int>("KategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriaId"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriaId");

                    b.ToTable("Kategoria");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Klient", b =>
                {
                    b.Property<int>("KlientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlientId"), 1L, 1);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataRejestracji")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("WojewodztwaWojewodztwoId")
                        .HasColumnType("int");

                    b.Property<string>("WojewodztwoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlientId");

                    b.HasIndex("WojewodztwaWojewodztwoId");

                    b.ToTable("Klient");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Podkategoria", b =>
                {
                    b.Property<int>("PodkategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PodkategoriaId"), 1L, 1);

                    b.Property<int?>("KategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PodkategoriaId");

                    b.HasIndex("KategoriaId");

                    b.ToTable("Podkategoria");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Producent", b =>
                {
                    b.Property<int>("ProducentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProducentId"), 1L, 1);

                    b.Property<string>("Kraj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RokZalozenia")
                        .HasColumnType("datetime2");

                    b.HasKey("ProducentId");

                    b.ToTable("Producent");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Produkt", b =>
                {
                    b.Property<int>("ProduktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduktId"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DataProdukcji")
                        .HasColumnType("datetime2");

                    b.Property<int>("KategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PodkategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("ProducentId")
                        .HasColumnType("int");

                    b.HasKey("ProduktId");

                    b.HasIndex("KategoriaId");

                    b.HasIndex("PodkategoriaId");

                    b.HasIndex("ProducentId");

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Wojewodztwo", b =>
                {
                    b.Property<int>("WojewodztwoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WojewodztwoId"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WojewodztwoId");

                    b.ToTable("Wojewodztwo");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Klient", b =>
                {
                    b.HasOne("Sklep_muzyczny.Models.Wojewodztwo", "Wojewodztwa")
                        .WithMany("Klienci")
                        .HasForeignKey("WojewodztwaWojewodztwoId");

                    b.Navigation("Wojewodztwa");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Podkategoria", b =>
                {
                    b.HasOne("Sklep_muzyczny.Models.Kategoria", "Kategoria")
                        .WithMany("Podkategorie")
                        .HasForeignKey("KategoriaId");

                    b.Navigation("Kategoria");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Produkt", b =>
                {
                    b.HasOne("Sklep_muzyczny.Models.Kategoria", "Kategoria")
                        .WithMany("Produkty")
                        .HasForeignKey("KategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sklep_muzyczny.Models.Podkategoria", "Podkategoria")
                        .WithMany("Produkty")
                        .HasForeignKey("PodkategoriaId");

                    b.HasOne("Sklep_muzyczny.Models.Producent", "Producent")
                        .WithMany("Produkty")
                        .HasForeignKey("ProducentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoria");

                    b.Navigation("Podkategoria");

                    b.Navigation("Producent");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Kategoria", b =>
                {
                    b.Navigation("Podkategorie");

                    b.Navigation("Produkty");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Podkategoria", b =>
                {
                    b.Navigation("Produkty");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Producent", b =>
                {
                    b.Navigation("Produkty");
                });

            modelBuilder.Entity("Sklep_muzyczny.Models.Wojewodztwo", b =>
                {
                    b.Navigation("Klienci");
                });
#pragma warning restore 612, 618
        }
    }
}
