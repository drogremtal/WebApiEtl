﻿// <auto-generated />
using System;
using Etl.DataAccess.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Etl.DataAccess.Postgres.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20240301131949_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Etl.DataAccess.Postgres.Model.DomainEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UniversitetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UniversitetId");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("Etl.DataAccess.Postgres.Model.UniversitetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AphaTwoCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StateProvince")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Etl.DataAccess.Postgres.Model.WebPageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UniversitetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UniversitetId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Etl.DataAccess.Postgres.Model.DomainEntity", b =>
                {
                    b.HasOne("Etl.DataAccess.Postgres.Model.UniversitetEntity", "Universitet")
                        .WithMany("domainEntities")
                        .HasForeignKey("UniversitetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Universitet");
                });

            modelBuilder.Entity("Etl.DataAccess.Postgres.Model.WebPageEntity", b =>
                {
                    b.HasOne("Etl.DataAccess.Postgres.Model.UniversitetEntity", "Universitet")
                        .WithMany("webPageEntities")
                        .HasForeignKey("UniversitetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Universitet");
                });

            modelBuilder.Entity("Etl.DataAccess.Postgres.Model.UniversitetEntity", b =>
                {
                    b.Navigation("domainEntities");

                    b.Navigation("webPageEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
