﻿// <auto-generated />
using Assignment4.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190407013242_Update2")]
    partial class Update2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment4.Models.EF_model+Company", b =>
                {
                    b.Property<string>("symbol")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("date");

                    b.Property<string>("name");

                    b.HasKey("symbol");

                    b.HasIndex("name");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Assignment4.Models.EF_model+Financials", b =>
                {
                    b.Property<string>("name")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("costOfRevenue");

                    b.Property<int>("grossProfit");

                    b.Property<int>("operatingRevenue");

                    b.Property<string>("reportDate");

                    b.Property<int>("totalRevenue");

                    b.HasKey("name");

                    b.ToTable("Financials");
                });

            modelBuilder.Entity("Assignment4.Models.EF_model+Company", b =>
                {
                    b.HasOne("Assignment4.Models.EF_model+Financials", "Financials")
                        .WithMany()
                        .HasForeignKey("name");
                });
#pragma warning restore 612, 618
        }
    }
}