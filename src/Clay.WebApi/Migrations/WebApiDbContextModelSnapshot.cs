﻿// <auto-generated />
using System;
using Clay.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clay.WebApi.Migrations
{
    [DbContext(typeof(WebApiDbContext))]
    partial class WebApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clay.WebApi.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Audit");
                });

            modelBuilder.Entity("Clay.WebApi.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuditId");

                    b.Property<string>("Identitfier")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Clay.WebApi.CardGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuditId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("PropertyId");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("PropertyId");

                    b.ToTable("CardGroups");
                });

            modelBuilder.Entity("Clay.WebApi.CardGroupLock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuditId");

                    b.Property<int?>("CardGroupId");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("CardGroupId");

                    b.ToTable("CardGroupLocks");
                });

            modelBuilder.Entity("Clay.WebApi.Lock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuditId");

                    b.Property<long>("AutoLockAfter");

                    b.Property<int?>("CardGroupLockId");

                    b.Property<string>("Description");

                    b.Property<int>("DoorState");

                    b.Property<string>("Identifier");

                    b.Property<int>("LockState");

                    b.Property<int?>("PropertyId");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("CardGroupLockId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Locks");
                });

            modelBuilder.Entity("Clay.WebApi.LockCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuditId");

                    b.Property<int?>("CardId");

                    b.Property<int?>("LockId");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("CardId");

                    b.HasIndex("LockId");

                    b.ToTable("LockCards");
                });

            modelBuilder.Entity("Clay.WebApi.LockEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuditId");

                    b.Property<int?>("CardId");

                    b.Property<int?>("CardOwnerWhenEventTriggerId");

                    b.Property<string>("Details");

                    b.Property<int>("EventType");

                    b.Property<int>("LockId");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("CardId");

                    b.HasIndex("CardOwnerWhenEventTriggerId");

                    b.HasIndex("LockId");

                    b.ToTable("LockEvents");
                });

            modelBuilder.Entity("Clay.WebApi.PersonData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuditId");

                    b.Property<int>("CardId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("CardId")
                        .IsUnique();

                    b.ToTable("PersonData");
                });

            modelBuilder.Entity("Clay.WebApi.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuditId");

                    b.Property<int?>("CardId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("OwnerUsername");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("CardId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Clay.WebApi.Card", b =>
                {
                    b.HasOne("Clay.WebApi.Audit", "Audit")
                        .WithMany()
                        .HasForeignKey("AuditId");
                });

            modelBuilder.Entity("Clay.WebApi.CardGroup", b =>
                {
                    b.HasOne("Clay.WebApi.Audit", "Audit")
                        .WithMany()
                        .HasForeignKey("AuditId");

                    b.HasOne("Clay.WebApi.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("Clay.WebApi.CardGroupLock", b =>
                {
                    b.HasOne("Clay.WebApi.Audit", "Audit")
                        .WithMany()
                        .HasForeignKey("AuditId");

                    b.HasOne("Clay.WebApi.CardGroup", "CardGroup")
                        .WithMany()
                        .HasForeignKey("CardGroupId");
                });

            modelBuilder.Entity("Clay.WebApi.Lock", b =>
                {
                    b.HasOne("Clay.WebApi.Audit", "Audit")
                        .WithMany()
                        .HasForeignKey("AuditId");

                    b.HasOne("Clay.WebApi.CardGroupLock")
                        .WithMany("Locks")
                        .HasForeignKey("CardGroupLockId");

                    b.HasOne("Clay.WebApi.Property", "Property")
                        .WithMany("Locks")
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("Clay.WebApi.LockCard", b =>
                {
                    b.HasOne("Clay.WebApi.Audit", "Audit")
                        .WithMany()
                        .HasForeignKey("AuditId");

                    b.HasOne("Clay.WebApi.Card", "Card")
                        .WithMany("Locks")
                        .HasForeignKey("CardId");

                    b.HasOne("Clay.WebApi.Lock", "Lock")
                        .WithMany()
                        .HasForeignKey("LockId");
                });

            modelBuilder.Entity("Clay.WebApi.LockEvent", b =>
                {
                    b.HasOne("Clay.WebApi.Audit", "Audit")
                        .WithMany()
                        .HasForeignKey("AuditId");

                    b.HasOne("Clay.WebApi.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId");

                    b.HasOne("Clay.WebApi.PersonData", "CardOwnerWhenEventTrigger")
                        .WithMany()
                        .HasForeignKey("CardOwnerWhenEventTriggerId");

                    b.HasOne("Clay.WebApi.Lock", "Lock")
                        .WithMany()
                        .HasForeignKey("LockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clay.WebApi.PersonData", b =>
                {
                    b.HasOne("Clay.WebApi.Audit", "Audit")
                        .WithMany()
                        .HasForeignKey("AuditId");

                    b.HasOne("Clay.WebApi.Card", "Card")
                        .WithOne("PersonData")
                        .HasForeignKey("Clay.WebApi.PersonData", "CardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clay.WebApi.Property", b =>
                {
                    b.HasOne("Clay.WebApi.Audit", "Audit")
                        .WithMany()
                        .HasForeignKey("AuditId");

                    b.HasOne("Clay.WebApi.Card")
                        .WithMany("Properties")
                        .HasForeignKey("CardId");
                });
#pragma warning restore 612, 618
        }
    }
}
