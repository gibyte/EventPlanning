﻿// <auto-generated />
using System;
using EventPlanning.Control;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace epControl.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231020080903_Url")]
    partial class Url
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("EventPlanning.Model.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HomeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventPlanning.Model.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("EventPlanning.Model.Nomenclature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Nomenclature");
                });

            modelBuilder.Entity("EventPlanning.Model.NomenclatureLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NomenclatureId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NomenclatureId");

                    b.ToTable("NomenclatureLink");
                });

            modelBuilder.Entity("EventPlanning.Model.Event", b =>
                {
                    b.HasOne("EventPlanning.Model.Home", null)
                        .WithMany("Events")
                        .HasForeignKey("HomeId");
                });

            modelBuilder.Entity("EventPlanning.Model.Nomenclature", b =>
                {
                    b.HasOne("EventPlanning.Model.Event", null)
                        .WithMany("Nomenclatures")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("EventPlanning.Model.NomenclatureLink", b =>
                {
                    b.HasOne("EventPlanning.Model.Nomenclature", null)
                        .WithMany("Links")
                        .HasForeignKey("NomenclatureId");
                });

            modelBuilder.Entity("EventPlanning.Model.Event", b =>
                {
                    b.Navigation("Nomenclatures");
                });

            modelBuilder.Entity("EventPlanning.Model.Home", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventPlanning.Model.Nomenclature", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}