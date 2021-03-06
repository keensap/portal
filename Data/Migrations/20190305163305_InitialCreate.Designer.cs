﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using KeenSap.Portal.Data;

namespace KeenSap.Portal.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190305163305_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("KeenSap.Portal.Data.Entities.EntityAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("ActionId")
                        .HasColumnName("action_id");

                    b.Property<int>("EntityId")
                        .HasColumnName("entity_id");

                    b.HasKey("Id");

                    b.ToTable("entity_actions");
                });

            modelBuilder.Entity("KeenSap.Portal.Data.Entities.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("EntityActionId")
                        .HasColumnName("entity_action_id");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("EntityActionId");

                    b.HasIndex("RoleId");

                    b.ToTable("permissions");
                });

            modelBuilder.Entity("KeenSap.Portal.Data.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnName("created_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("KeenSap.Portal.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(30);

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(30);

                    b.Property<string>("Salt")
                        .HasColumnName("salt");

                    b.Property<string>("Token")
                        .HasColumnName("token");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnName("updated_by");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("KeenSap.Portal.Data.Entities.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("KeenSap.Portal.Data.Entities.Permission", b =>
                {
                    b.HasOne("KeenSap.Portal.Data.Entities.EntityAction", "EntityAction")
                        .WithMany("Permissions")
                        .HasForeignKey("EntityActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KeenSap.Portal.Data.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KeenSap.Portal.Data.Entities.UserRole", b =>
                {
                    b.HasOne("KeenSap.Portal.Data.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KeenSap.Portal.Data.Entities.User", "User")
                        .WithMany("user_roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
