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
    [Migration("20231018053912_First")]
    partial class First
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

            modelBuilder.Entity("epModel.Nomenclature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Nomenclature");
                });

            modelBuilder.Entity("EventPlanning.Model.Event", b =>
                {
                    b.HasOne("EventPlanning.Model.Home", null)
                        .WithMany("Events")
                        .HasForeignKey("HomeId");
                });

            modelBuilder.Entity("epModel.Nomenclature", b =>
                {
                    b.HasOne("EventPlanning.Model.Event", null)
                        .WithMany("Nomenclatures")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("EventPlanning.Model.Event", b =>
                {
                    b.Navigation("Nomenclatures");
                });

            modelBuilder.Entity("EventPlanning.Model.Home", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
