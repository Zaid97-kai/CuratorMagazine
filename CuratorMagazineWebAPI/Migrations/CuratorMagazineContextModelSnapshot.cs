// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 12-22-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-22-2022
// ***********************************************************************
// <copyright file="CuratorMagazineContextModelSnapshot.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using CuratorMagazineWebAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CuratorMagazineWebAPI.Migrations
{
    /// <summary>
    /// Class CuratorMagazineContextModelSnapshot.
    /// Implements the <see cref="ModelSnapshot" />
    /// </summary>
    /// <seealso cref="ModelSnapshot" />
    [DbContext(typeof(CuratorMagazineContext))]
    partial class CuratorMagazineContextModelSnapshot : ModelSnapshot
    {
        /// <summary>
        /// Builds the model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Domains.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Domains.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WorkName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Domains.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Domains.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FatherId")
                        .HasColumnType("integer");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int?>("MotherId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("bytea");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("FatherId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MotherId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasColumnType("text");

                    b.Property<string>("Xml")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Domains.User", b =>
                {
                    b.HasOne("CuratorMagazineWebAPI.Models.Entities.Division", "Division")
                        .WithMany("Users")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CuratorMagazineWebAPI.Models.Entities.Domains.Parent", "Father")
                        .WithMany("FatherChildrens")
                        .HasForeignKey("FatherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CuratorMagazineWebAPI.Models.Entities.Domains.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("CuratorMagazineWebAPI.Models.Entities.Domains.Parent", "Mother")
                        .WithMany("MotherChildrens")
                        .HasForeignKey("MotherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CuratorMagazineWebAPI.Models.Entities.Domains.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Division");

                    b.Navigation("Father");

                    b.Navigation("Group");

                    b.Navigation("Mother");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Division", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Domains.Group", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Domains.Parent", b =>
                {
                    b.Navigation("FatherChildrens");

                    b.Navigation("MotherChildrens");
                });

            modelBuilder.Entity("CuratorMagazineWebAPI.Models.Entities.Domains.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
