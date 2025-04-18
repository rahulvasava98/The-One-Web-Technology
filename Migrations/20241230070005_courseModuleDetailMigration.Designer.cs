﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using The_One_Web_Technology.Data;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    [DbContext(typeof(Datacontext))]
    [Migration("20241230070005_courseModuleDetailMigration")]
    partial class courseModuleDetailMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("The_One_Web_Technology.Data.cartMst", b =>
                {
                    b.Property<int>("cartItemid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cartItemid"));

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.Property<string>("courseInstructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("courseWallpaper")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cartItemid");

                    b.ToTable("cartMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.categoriesMst", b =>
                {
                    b.Property<int>("categoriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoriesId"));

                    b.Property<string>("categoriesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("categoriestatus")
                        .HasColumnType("bit");

                    b.HasKey("categoriesId");

                    b.ToTable("categoriesMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.contactMst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("contactMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.courseCategoriesMst", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("courseCategoriesStatus")
                        .HasColumnType("bit");

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("courseCategoriesMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.courseDetailsMst", b =>
                {
                    b.Property<int>("courseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("courseId"));

                    b.Property<bool>("courseActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("courseCategories")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("courseInstructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("courseLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("courseWallpaper")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("videoLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("courseId");

                    b.ToTable("courseDetailsMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.courseLikeMst", b =>
                {
                    b.Property<int>("courselikeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("courselikeID"));

                    b.Property<int>("courseIds")
                        .HasColumnType("int");

                    b.Property<DateTime>("courseLikeTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("courselikedstatus")
                        .HasColumnType("bit");

                    b.Property<int>("userIds")
                        .HasColumnType("int");

                    b.HasKey("courselikeID");

                    b.ToTable("courseLikeMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.courseModuleDetailsMst", b =>
                {
                    b.Property<int>("courseModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("courseModuleId"));

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.HasKey("courseModuleId");

                    b.HasIndex("courseId");

                    b.ToTable("courseModuleDetailsMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.courseRequestHandleMst", b =>
                {
                    b.Property<int>("cRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cRequestId"));

                    b.Property<bool>("courseAccesstatus")
                        .HasColumnType("bit");

                    b.Property<int>("courseDetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("courseRequestTIme")
                        .HasColumnType("datetime2");

                    b.Property<string>("courseRequestedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentRequestedId")
                        .HasColumnType("int");

                    b.HasKey("cRequestId");

                    b.ToTable("courseRequestHandleMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.coursecollectionMst", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("courseStatus")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("coursecollectionMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.serviceMst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("serviceStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("serviceMsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.serviceRegistrationMaster", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("clientId"));

                    b.Property<string>("clientPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clientReferenceCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clientReferenceId")
                        .HasColumnType("int");

                    b.Property<string>("clientemail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clientfirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clientlastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clientlocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clientmessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clientservice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("clientId");

                    b.ToTable("serviceRegistrationMasters");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.trainingRegistrationmst", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("educationQualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("referenceCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("referenceId")
                        .HasColumnType("int");

                    b.Property<string>("trainingRegistrationPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("yourMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("trainingRegistrationmsts");
                });

            modelBuilder.Entity("The_One_Web_Technology.Data.courseModuleDetailsMst", b =>
                {
                    b.HasOne("The_One_Web_Technology.Data.courseDetailsMst", "courseDetailsMst")
                        .WithMany()
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courseDetailsMst");
                });
#pragma warning restore 612, 618
        }
    }
}
