﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using OnlineMarket.DataAccess;
using System;

namespace OnlineMarket.Web.Migrations
{
    [DbContext(typeof(OnlineMarketContext))]
    partial class OnlineMarketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.AccountDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountOwnerId");

                    b.Property<decimal>("AvailableBalance")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("AccountOwnerId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.AccountOwnerDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AccountOwnerDataModel");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AccountOwnerDataModel");
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.CurrentRateDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ItemTypeId");

                    b.Property<decimal>("Rate")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId")
                        .IsUnique();

                    b.ToTable("CurrentRate");
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.ExchangeRatesDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ItemTypeId");

                    b.Property<decimal>("Rate")
                        .HasColumnType("money");

                    b.Property<DateTime>("СhangeDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("СhangeDate");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.ItemTypeDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ItemType");
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.OperationArchiveDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountFromId");

                    b.Property<Guid>("AccountToId");

                    b.Property<Guid>("ItemTypeId");

                    b.Property<decimal>("OperationAmount");

                    b.Property<DateTime>("OperationDate");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("OperationArchive");
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.StorageDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<Guid>("ItemTypeId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("StorageAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.StoreDataModel", b =>
                {
                    b.HasBaseType("OnlineMarket.DataAccess.Entities.AccountOwnerDataModel");

                    b.Property<string>("Name");

                    b.ToTable("Store");

                    b.HasDiscriminator().HasValue("StoreDataModel");
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.UserDataModel", b =>
                {
                    b.HasBaseType("OnlineMarket.DataAccess.Entities.AccountOwnerDataModel");

                    b.Property<string>("Email");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("UserDataModel");
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.AccountDataModel", b =>
                {
                    b.HasOne("OnlineMarket.DataAccess.Entities.AccountOwnerDataModel", "AccountOwner")
                        .WithMany()
                        .HasForeignKey("AccountOwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.CurrentRateDataModel", b =>
                {
                    b.HasOne("OnlineMarket.DataAccess.Entities.ItemTypeDataModel", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.ExchangeRatesDataModel", b =>
                {
                    b.HasOne("OnlineMarket.DataAccess.Entities.ItemTypeDataModel", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.OperationArchiveDataModel", b =>
                {
                    b.HasOne("OnlineMarket.DataAccess.Entities.ItemTypeDataModel", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMarket.DataAccess.Entities.StorageDataModel", b =>
                {
                    b.HasOne("OnlineMarket.DataAccess.Entities.AccountDataModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineMarket.DataAccess.Entities.ItemTypeDataModel", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
