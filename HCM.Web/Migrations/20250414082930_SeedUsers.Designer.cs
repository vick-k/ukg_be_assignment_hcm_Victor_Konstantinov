﻿// <auto-generated />
using System;
using HCM.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HCM.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250414082930_SeedUsers")]
    partial class SeedUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HCM.Web.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasComment("The identifier of the department");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The first name of the employee");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int")
                        .HasComment("The identifier of the job title");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasComment("The last name of the employee");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<decimal>("Salary")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("The current salary of the employee");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("21e27e05-cbee-44b0-88c2-0a6473769deb"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ee4f6cc3-94f9-494c-b470-235d4c34fc96",
                            DepartmentId = 4,
                            Email = "i.ivanov@hcm.com",
                            EmailConfirmed = false,
                            FirstName = "Ivan",
                            IsDeleted = false,
                            JobTitleId = 3,
                            LastName = "Ivanov",
                            LockoutEnabled = true,
                            NormalizedEmail = "I.IVANOV@HCM.COM",
                            NormalizedUserName = "IVAN",
                            PasswordHash = "AQAAAAIAAYagAAAAEEiGyHne4+XmmPwsH1pKWpVKzh7KqSzppuHL001gpTOKjiHMPXlwVjXp7OBxdWjyWg==",
                            PhoneNumberConfirmed = false,
                            Salary = 1000m,
                            SecurityStamp = "80390b3f-b152-4194-9dda-8b85400bbf69",
                            TwoFactorEnabled = false,
                            UserName = "ivan"
                        },
                        new
                        {
                            Id = new Guid("9835d1fa-775f-4396-b50e-5135a2112208"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "52b51e41-1efb-46f6-8f66-70f05076ad5c",
                            DepartmentId = 6,
                            Email = "p.petrov@hcm.com",
                            EmailConfirmed = false,
                            FirstName = "Peter",
                            IsDeleted = false,
                            JobTitleId = 5,
                            LastName = "Petrov",
                            LockoutEnabled = true,
                            NormalizedEmail = "P.PETROV@HCM.COM",
                            NormalizedUserName = "PETER",
                            PasswordHash = "AQAAAAIAAYagAAAAEEgrauZPwkipRnpUF8eqkFzSj8XginHoexlHYF+zbcs++SGN+RO3jYgpb3aNG1E82w==",
                            PhoneNumberConfirmed = false,
                            Salary = 2500m,
                            SecurityStamp = "afc7ede9-4c46-48f1-80c7-a6c9bf7cbb7a",
                            TwoFactorEnabled = false,
                            UserName = "peter"
                        },
                        new
                        {
                            Id = new Guid("1211a2a3-dcd7-4a3d-be2d-aa8d07af4465"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a88705e9-dbb8-49ea-b6dd-d45c9499a64a",
                            DepartmentId = 6,
                            Email = "g.georgiev@hcm.com",
                            EmailConfirmed = false,
                            FirstName = "George",
                            IsDeleted = false,
                            JobTitleId = 6,
                            LastName = "Georgiev",
                            LockoutEnabled = true,
                            NormalizedEmail = "G.GEORGIEV@HCM.COM",
                            NormalizedUserName = "GEORGE",
                            PasswordHash = "AQAAAAIAAYagAAAAELIzFatM08flQORp5H615yXvfhZh9KlZKutUaxQMQ3Bme8qWwZX+HQOwNCvrSnha7Q==",
                            PhoneNumberConfirmed = false,
                            Salary = 3500m,
                            SecurityStamp = "5b670aa2-3db4-447c-9a0c-0e0514018da4",
                            TwoFactorEnabled = false,
                            UserName = "george"
                        });
                });

            modelBuilder.Entity("HCM.Web.Data.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The identifier of the department");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasComment("The name of the department");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Human Resources"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Finance and Accounting"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Product Management"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Software Development"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Quality Assurance"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "IT Support"
                        });
                });

            modelBuilder.Entity("HCM.Web.Data.Models.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The identifier of the job title");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The name of the job title");

                    b.HasKey("Id");

                    b.ToTable("JobTitles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Senior Software Engineer"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Junior Software Engineer"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Project Manager"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Business Analyst"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "QA Specialist"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "QA Lead"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "HR Specialist"
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            Name = "HR Lead"
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Name = "System Administrator"
                        },
                        new
                        {
                            Id = 10,
                            IsDeleted = false,
                            Name = "Account Manager"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HCM.Web.Data.Models.ApplicationUser", b =>
                {
                    b.HasOne("HCM.Web.Data.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HCM.Web.Data.Models.JobTitle", "JobTitle")
                        .WithMany("Employees")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("HCM.Web.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("HCM.Web.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HCM.Web.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("HCM.Web.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HCM.Web.Data.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HCM.Web.Data.Models.JobTitle", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
