﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Starcatcher.Infrastructure.Data;

#nullable disable

namespace Starcatcher.Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Starcatcher.Domain.Entities.Consortium", b =>
                {
                    b.Property<int>("ConsortiumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsortiumId"));

                    b.Property<DateTime?>("ClosedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConsortiumId");

                    b.ToTable("Consortia");

                    b.HasData(
                        new
                        {
                            ConsortiumId = 1,
                            CreatedAt = new DateTime(2024, 10, 21, 9, 52, 13, 113, DateTimeKind.Local).AddTicks(297),
                            Description = "Consórcio para aquisição de veículos",
                            Name = "Consórcio de Carros"
                        },
                        new
                        {
                            ConsortiumId = 2,
                            CreatedAt = new DateTime(2024, 10, 21, 9, 52, 13, 113, DateTimeKind.Local).AddTicks(305),
                            Description = "Consórcio para aquisição de imóveis",
                            Name = "Consórcio de Imóveis"
                        },
                        new
                        {
                            ConsortiumId = 3,
                            CreatedAt = new DateTime(2024, 10, 21, 9, 52, 13, 113, DateTimeKind.Local).AddTicks(311),
                            Description = "Consórcio para aquisição de motocicletas",
                            Name = "Consórcio de Motos"
                        });
                });

            modelBuilder.Entity("Starcatcher.Domain.Entities.Quota", b =>
                {
                    b.Property<int>("QuotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuotaId"));

                    b.Property<int>("ConsortiumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuotaNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("QuotaId");

                    b.HasIndex("ConsortiumId");

                    b.HasIndex("UserId");

                    b.ToTable("Quotas");
                });

            modelBuilder.Entity("Starcatcher.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Starcatcher.Domain.Entities.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WalletId"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WalletId");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Starcatcher.Domain.Entities.Quota", b =>
                {
                    b.HasOne("Starcatcher.Domain.Entities.Consortium", "Consortium")
                        .WithMany("Quotas")
                        .HasForeignKey("ConsortiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Starcatcher.Domain.Entities.User", "User")
                        .WithMany("Quotas")
                        .HasForeignKey("UserId");

                    b.Navigation("Consortium");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Starcatcher.Domain.Entities.Wallet", b =>
                {
                    b.HasOne("Starcatcher.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Starcatcher.Domain.Entities.Consortium", b =>
                {
                    b.Navigation("Quotas");
                });

            modelBuilder.Entity("Starcatcher.Domain.Entities.User", b =>
                {
                    b.Navigation("Quotas");
                });
#pragma warning restore 612, 618
        }
    }
}
