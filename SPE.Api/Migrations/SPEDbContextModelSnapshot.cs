﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SPE.DataModel.Context;

namespace SPE.Api.Migrations
{
    [DbContext(typeof(SPEDbContext))]
    partial class SPEDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SPE.DataModel.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PermissionId")
                        .UseIdentityColumn();

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("PermissionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("PermissionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionTypeId");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("SPE.DataModel.Entities.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PermissionTypeId")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("PermissionType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Enfermedad"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Diligencias"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Otros"
                        });
                });

            modelBuilder.Entity("SPE.DataModel.Entities.Permission", b =>
                {
                    b.HasOne("SPE.DataModel.Entities.PermissionType", "PermissionType")
                        .WithMany("Permission")
                        .HasForeignKey("PermissionTypeId")
                        .HasConstraintName("Fk_Permission_PermissionType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PermissionType");
                });

            modelBuilder.Entity("SPE.DataModel.Entities.PermissionType", b =>
                {
                    b.Navigation("Permission");
                });
#pragma warning restore 612, 618
        }
    }
}
