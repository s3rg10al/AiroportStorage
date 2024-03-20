﻿// <auto-generated />
using System;
using AirportStorage.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirportStorage.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.27");

            modelBuilder.Entity("AirportStorage.Domain.Entities.company.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Hangar.Hangar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Hangar", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Owner.Owner", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("CantJets")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("PhoneNumb")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Planes.Planes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("CantKmsDesdeMant")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("CantKmsTotales")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Estado")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Planes", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Staff.Staff", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Exp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("PhoneNumb")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Sueldo")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Years")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Store.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("CantPiezas")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UltimoInv")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Store", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Workshop.Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Ability")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAbility")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("specialty")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Workshop", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Planes.Commercial", b =>
                {
                    b.HasBaseType("AirportStorage.Domain.Entities.Planes.Planes");

                    b.Property<int>("HangarId")
                        .HasColumnType("INTEGER");

                    b.ToTable("Commercials", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Planes.Jets", b =>
                {
                    b.HasBaseType("AirportStorage.Domain.Entities.Planes.Planes");

                    b.Property<int>("LuxuryLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.ToTable("Jets", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Staff.AssuranceStaff", b =>
                {
                    b.HasBaseType("AirportStorage.Domain.Entities.Staff.Staff");

                    b.Property<uint>("CantHorasExtras")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("CantHorasTrabajadas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HangarId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("PagoxHoras")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("PagoxHorasExtras")
                        .HasColumnType("INTEGER");

                    b.ToTable("AssuranceStaff", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Staff.Mechanic", b =>
                {
                    b.HasBaseType("AirportStorage.Domain.Entities.Staff.Staff");

                    b.Property<uint>("CantRep")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("PagoxRep")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("INTEGER");

                    b.ToTable("Mechanic", (string)null);
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Planes.Commercial", b =>
                {
                    b.HasOne("AirportStorage.Domain.Entities.Planes.Planes", null)
                        .WithOne()
                        .HasForeignKey("AirportStorage.Domain.Entities.Planes.Commercial", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Planes.Jets", b =>
                {
                    b.HasOne("AirportStorage.Domain.Entities.Planes.Planes", null)
                        .WithOne()
                        .HasForeignKey("AirportStorage.Domain.Entities.Planes.Jets", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Staff.AssuranceStaff", b =>
                {
                    b.HasOne("AirportStorage.Domain.Entities.Staff.Staff", null)
                        .WithOne()
                        .HasForeignKey("AirportStorage.Domain.Entities.Staff.AssuranceStaff", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirportStorage.Domain.Entities.Staff.Mechanic", b =>
                {
                    b.HasOne("AirportStorage.Domain.Entities.Staff.Staff", null)
                        .WithOne()
                        .HasForeignKey("AirportStorage.Domain.Entities.Staff.Mechanic", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
