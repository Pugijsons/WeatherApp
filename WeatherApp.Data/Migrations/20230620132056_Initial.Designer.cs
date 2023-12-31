﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp.Data;

#nullable disable

namespace WeatherApp.Data.Migrations
{
    [DbContext(typeof(WeatherAppDbContext))]
    [Migration("20230620132056_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WeatherApp.Core.Models.CurrentWeatherModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("is_day")
                        .HasColumnType("int");

                    b.Property<double>("temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<int>("weathercode")
                        .HasColumnType("int");

                    b.Property<double>("winddirection")
                        .HasColumnType("float");

                    b.Property<double>("windspeed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CurrentWeatherModel");
                });

            modelBuilder.Entity("WeatherApp.Core.Models.IPCallResponseModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<double>("lat")
                        .HasColumnType("float");

                    b.Property<double>("lon")
                        .HasColumnType("float");

                    b.Property<string>("query")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IPCallResponse");
                });

            modelBuilder.Entity("WeatherApp.Core.Models.WeatherData", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("current_weatherId")
                        .HasColumnType("int");

                    b.Property<double>("elevation")
                        .HasColumnType("float");

                    b.Property<double>("generationtime_ms")
                        .HasColumnType("float");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<string>("timezone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("timezone_abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("utc_offset_seconds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("current_weatherId");

                    b.ToTable("WeatherData");
                });

            modelBuilder.Entity("WeatherApp.Core.Models.WeatherData", b =>
                {
                    b.HasOne("WeatherApp.Core.Models.CurrentWeatherModel", "current_weather")
                        .WithMany()
                        .HasForeignKey("current_weatherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("current_weather");
                });
#pragma warning restore 612, 618
        }
    }
}
