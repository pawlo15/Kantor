﻿// <auto-generated />
using System;
using Kantor.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kantor.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Account.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Account.AccountBalance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<byte>("CurrencyId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("AccountBalance", (string)null);
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Auth.Credentials", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Credentials", (string)null);
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Operations.Currency", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Currency", (string)null);
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Operations.OperationHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("CurrencyId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("numeric");

                    b.Property<byte>("OperationTypeId")
                        .HasColumnType("smallint");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("OperationTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("OperationHistory", (string)null);
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Operations.OperationType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OperationType", (string)null);
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecureKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.User.UserHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OperationId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserHistory", (string)null);
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.User.UserOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserOperation", (string)null);
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Account.Account", b =>
                {
                    b.HasOne("Kantor.Infrastructure.Entities.User.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("Kantor.Infrastructure.Entities.Account.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Account.AccountBalance", b =>
                {
                    b.HasOne("Kantor.Infrastructure.Entities.Account.Account", "Account")
                        .WithMany("AccountBalances")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kantor.Infrastructure.Entities.Operations.Currency", "Currency")
                        .WithMany("AccountBalances")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Auth.Credentials", b =>
                {
                    b.HasOne("Kantor.Infrastructure.Entities.User.User", "User")
                        .WithOne("Credentials")
                        .HasForeignKey("Kantor.Infrastructure.Entities.Auth.Credentials", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Operations.OperationHistory", b =>
                {
                    b.HasOne("Kantor.Infrastructure.Entities.Operations.Currency", "Currency")
                        .WithMany("History")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kantor.Infrastructure.Entities.Operations.OperationType", "OperationType")
                        .WithMany("History")
                        .HasForeignKey("OperationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kantor.Infrastructure.Entities.User.User", "User")
                        .WithMany("OperationHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("OperationType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.User.UserHistory", b =>
                {
                    b.HasOne("Kantor.Infrastructure.Entities.User.UserOperation", "Operation")
                        .WithMany("History")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kantor.Infrastructure.Entities.User.User", "User")
                        .WithMany("History")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Account.Account", b =>
                {
                    b.Navigation("AccountBalances");
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Operations.Currency", b =>
                {
                    b.Navigation("AccountBalances");

                    b.Navigation("History");
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.Operations.OperationType", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.User.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Credentials")
                        .IsRequired();

                    b.Navigation("History");

                    b.Navigation("OperationHistory");
                });

            modelBuilder.Entity("Kantor.Infrastructure.Entities.User.UserOperation", b =>
                {
                    b.Navigation("History");
                });
#pragma warning restore 612, 618
        }
    }
}
