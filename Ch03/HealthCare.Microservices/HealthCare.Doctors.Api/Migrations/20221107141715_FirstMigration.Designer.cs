﻿// <auto-generated />
using System;
using HealthCare.Doctors.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthCare.Doctors.Api.Migrations
{
    [DbContext(typeof(DoctorsDbContext))]
    [Migration("20221107141715_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("HealthCare.Doctors.Api.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SpecializationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("HealthCare.Doctors.Api.Models.Doctor", b =>
                {
                    b.HasOne("Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId");

                    b.Navigation("Specialization");
                });
#pragma warning restore 612, 618
        }
    }
}
