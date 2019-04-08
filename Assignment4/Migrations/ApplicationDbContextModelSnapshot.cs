﻿// <auto-generated />
using System;
using Assignment4.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment4.Models.EF_model+Book", b =>
                {
                    b.Property<float>("quote");

                    b.Property<float>("asks");

                    b.Property<float>("bids");

                    b.Property<float>("systemEvent");

                    b.Property<float>("trades");

                    b.HasKey("quote");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Assignment4.Models.EF_model+Company", b =>
                {
                    b.Property<string>("symbol")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("symbol");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Assignment4.Models.EF_model+Dividend", b =>
                {
                    b.Property<DateTime>("Exdate");

                    b.Property<float?>("Amount");

                    b.Property<DateTime>("Payment_date");

                    b.Property<DateTime>("Record_date");

                    b.Property<string>("qualified");

                    b.Property<string>("type");

                    b.HasKey("Exdate");

                    b.ToTable("Dividend");
                });

            modelBuilder.Entity("Assignment4.Models.EF_model+Price", b =>
                {
                    b.Property<double>("Amount");

                    b.Property<string>("Symbol");

                    b.HasKey("Amount");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("Assignment4.Models.EF_model+ShortInterestList", b =>
                {
                    b.Property<DateTime>("SettlementDate");

                    b.Property<int>("AverageDailyVolume");

                    b.Property<string>("CompanyName");

                    b.Property<int>("CurrentShortInterest");

                    b.Property<double>("DaystoCover");

                    b.Property<string>("NewIssueFlag");

                    b.Property<double>("PercentChange");

                    b.Property<int>("PreviousShortInterest");

                    b.Property<string>("RevisionFlag");

                    b.Property<string>("SecurityName");

                    b.Property<string>("StockAdjustmentFlag");

                    b.Property<string>("SymbolinCMSSymbology");

                    b.Property<string>("SymbolinCQSSymbology");

                    b.Property<string>("SymbolinINETSymbology");

                    b.HasKey("SettlementDate");

                    b.ToTable("ShortInterestList");
                });
#pragma warning restore 612, 618
        }
    }
}
