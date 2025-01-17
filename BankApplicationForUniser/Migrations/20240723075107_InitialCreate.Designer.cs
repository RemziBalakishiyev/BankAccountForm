﻿// <auto-generated />
using System;
using BankApplicationForUniser.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankApplicationForUniser.Migrations
{
    [DbContext(typeof(BankCardUniserContext))]
    [Migration("20240723075107_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankApplicationForUniser.Entities.BankCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("CardTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("CreditId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2026, 7, 23, 11, 51, 6, 450, DateTimeKind.Local).AddTicks(6487));

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.HasIndex("CreditId")
                        .IsUnique()
                        .HasFilter("[CreditId] IS NOT NULL");

                    b.HasIndex("CustomerId");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("BankApplicationForUniser.Entities.CardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "Debet"
                        },
                        new
                        {
                            Id = 2,
                            Value = "Credit"
                        });
                });

            modelBuilder.Entity("BankApplicationForUniser.Entities.Credit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("BankCardId")
                        .HasColumnType("int");

                    b.Property<float>("Percent")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("BankApplicationForUniser.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BankApplicationForUniser.Entities.CustomerWorkDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("CustomerWorkDetails");
                });

            modelBuilder.Entity("BankApplicationForUniser.Entities.BankCard", b =>
                {
                    b.HasOne("BankApplicationForUniser.Entities.CardType", "CardType")
                        .WithMany("BankCards")
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankApplicationForUniser.Entities.Credit", "Credit")
                        .WithOne("BankCard")
                        .HasForeignKey("BankApplicationForUniser.Entities.BankCard", "CreditId");

                    b.HasOne("BankApplicationForUniser.Entities.Customer", "Customer")
                        .WithMany("BankCards")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");

                    b.Navigation("Credit");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BankApplicationForUniser.Entities.CustomerWorkDetail", b =>
                {
                    b.HasOne("BankApplicationForUniser.Entities.Customer", "Customer")
                        .WithOne("CustomerWorkDetail")
                        .HasForeignKey("BankApplicationForUniser.Entities.CustomerWorkDetail", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BankApplicationForUniser.Entities.CardType", b =>
                {
                    b.Navigation("BankCards");
                });

            modelBuilder.Entity("BankApplicationForUniser.Entities.Credit", b =>
                {
                    b.Navigation("BankCard")
                        .IsRequired();
                });

            modelBuilder.Entity("BankApplicationForUniser.Entities.Customer", b =>
                {
                    b.Navigation("BankCards");

                    b.Navigation("CustomerWorkDetail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
