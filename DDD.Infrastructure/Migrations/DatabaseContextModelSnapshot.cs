﻿// <auto-generated />
using System;
using DDD.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDD.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DDD.Domain.Core.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("description");

                    b.Property<DateTime>("ManufacturingDate")
                        .HasColumnType("datetime")
                        .HasColumnName("manufacturing_date");

                    b.Property<bool>("State")
                        .HasColumnType("bit")
                        .HasColumnName("state");

                    b.Property<DateTime>("ValidityDate")
                        .HasColumnType("datetime")
                        .HasColumnName("validity_date");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DDD.Domain.Core.Entities.Product", b =>
                {
                    b.OwnsOne("DDD.Domain.Core.Entities.Provider", "Provider", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("descripcion_provider");

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("phone_number_provider");

                            b1.Property<string>("ProviderId")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("provider_id");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Provider")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
