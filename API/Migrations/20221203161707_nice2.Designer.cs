﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221203161707_nice2")]
    partial class nice2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BankName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Borough")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ContactNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Nip")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<int?>("PostalCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("Town")
                        .HasColumnType("TEXT");

                    b.Property<string>("Township")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Voivodeship")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryCode")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DiscountJobs")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DiscountParts")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nip")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("API.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("AdmissionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientDescription")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeadlineDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FuelLevel")
                        .HasColumnType("TEXT");

                    b.Property<string>("InvoiceId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Mileage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RepairDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TotalGross")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalJobsGross")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalJobsNet")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalNet")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalPartsGross")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalPartsNet")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ClientId");

                    b.HasIndex("StatusId")
                        .IsUnique();

                    b.HasIndex("VehicleId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.Entities.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApprovedProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("ApprovedSalesPriceGross")
                        .HasColumnType("REAL");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeliveryTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsProvided")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("API.Entities.OrderService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("ApprovedCostGross")
                        .HasColumnType("REAL");

                    b.Property<float>("ApprovedEstimatedTime")
                        .HasColumnType("REAL");

                    b.Property<string>("ApprovedServiceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("WorkedTime")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderServices");
                });

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Availability")
                        .HasColumnType("INTEGER");

                    b.Property<float>("BuyPriceGross")
                        .HasColumnType("REAL");

                    b.Property<float>("BuyPriceNet")
                        .HasColumnType("REAL");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ean")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastDeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Margin")
                        .HasColumnType("REAL");

                    b.Property<float>("Markup")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notice")
                        .HasColumnType("TEXT");

                    b.Property<float>("Profit")
                        .HasColumnType("REAL");

                    b.Property<int>("Reserved")
                        .HasColumnType("INTEGER");

                    b.Property<float>("SalesPriceGross")
                        .HasColumnType("REAL");

                    b.Property<float>("SalesPriceNet")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<float>("Vat")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("CostGross")
                        .HasColumnType("REAL");

                    b.Property<float>("CostNet")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<float>("EstimatedTime")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("TotalGross")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalNet")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("API.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("EmailSend")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("HasInvoice")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("API.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CurrentOwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EngineCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("EngineFuel")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EnginePower")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EnginePowerUnit")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FirstRegistration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductionDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TechnicalInspectionEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Vin")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CurrentOwnerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("API.Entities.Client", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("Clients")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("API.Entities.Order", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId");

                    b.HasOne("API.Entities.Status", "Status")
                        .WithOne("Order")
                        .HasForeignKey("API.Entities.Order", "StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Vehicle", "Vehicle")
                        .WithMany("Orders")
                        .HasForeignKey("VehicleId");

                    b.Navigation("AppUser");

                    b.Navigation("Client");

                    b.Navigation("Status");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("API.Entities.OrderProduct", b =>
                {
                    b.HasOne("API.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Entities.OrderService", b =>
                {
                    b.HasOne("API.Entities.Order", "Order")
                        .WithMany("OrderServices")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("Products")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("API.Entities.Service", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("Services")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("API.Entities.Vehicle", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("Vehicles")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Client", "CurrentOwner")
                        .WithMany("Vehicles")
                        .HasForeignKey("CurrentOwnerId");

                    b.Navigation("AppUser");

                    b.Navigation("CurrentOwner");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("Services");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("API.Entities.Client", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("API.Entities.Order", b =>
                {
                    b.Navigation("OrderServices");
                });

            modelBuilder.Entity("API.Entities.Status", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("API.Entities.Vehicle", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
