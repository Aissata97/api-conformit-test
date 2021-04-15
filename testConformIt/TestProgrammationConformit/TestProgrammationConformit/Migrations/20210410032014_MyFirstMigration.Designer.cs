﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestProgrammationConformit.Infrastructures;

namespace TestProgrammationConformit.Migrations
{
    [DbContext(typeof(ConformitContext))]
    [Migration("20210410032014_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TestProgrammationConformit.Models.Commentaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("EvenementId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EvenementId");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("TestProgrammationConformit.Models.Evenement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Organisateur")
                        .HasColumnType("text");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Evenements");
                });

            modelBuilder.Entity("TestProgrammationConformit.Models.Commentaire", b =>
                {
                    b.HasOne("TestProgrammationConformit.Models.Evenement", "Evenement")
                        .WithMany("Commentaires")
                        .HasForeignKey("EvenementId");
                });
#pragma warning restore 612, 618
        }
    }
}