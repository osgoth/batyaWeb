﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using batyaWeb.Models;

namespace batyaWeb.Migrations
{
    [DbContext(typeof(SiteContext))]
    [Migration("20190321000155_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("batyaWeb.Models.Site", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Domain");

                    b.Property<string>("IP");

                    b.HasKey("ID");

                    b.ToTable("Sites");
                });
#pragma warning restore 612, 618
        }
    }
}
