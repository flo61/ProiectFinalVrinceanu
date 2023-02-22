﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vacanta.Data;

#nullable disable

namespace vacanta.Migrations
{
    [DbContext(typeof(vacantaContext))]
    [Migration("20230222194528_cici")]
    partial class cici
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("vacanta.Models.Continent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireContinent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("vacanta.Models.Luna", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<decimal>("Buget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ContinentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPlecare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Persoane")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suveniruri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ContinentID");

                    b.ToTable("Luna");
                });

            modelBuilder.Entity("vacanta.Models.Luna", b =>
                {
                    b.HasOne("vacanta.Models.Continent", "Continent")
                        .WithMany("Luni")
                        .HasForeignKey("ContinentID");

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("vacanta.Models.Continent", b =>
                {
                    b.Navigation("Luni");
                });
#pragma warning restore 612, 618
        }
    }
}