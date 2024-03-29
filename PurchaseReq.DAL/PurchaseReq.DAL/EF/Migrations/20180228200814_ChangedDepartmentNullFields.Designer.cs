﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using PurchaseReq.DAL.EF;
using System;

namespace PurchaseReq.DAL.EF.Migrations
{
    [DbContext(typeof(PurchaseReqContext))]
    [Migration("20180228200814_ChangedDepartmentNullFields")]
    partial class ChangedDepartmentNullFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.AlternativeRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlternativeId");

                    b.Property<int>("RequestId");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("AlternativeId");

                    b.HasIndex("RequestId");

                    b.ToTable("AlternativeRequest","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Approval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApprovalName")
                        .HasMaxLength(20);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Approval","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttachmentPath")
                        .IsRequired();

                    b.Property<int>("RequestId");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Attachments","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.BudgetCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("BudgetCodeName");

                    b.Property<int>("DA");

                    b.Property<int>("Function");

                    b.Property<int>("Parent");

                    b.Property<int>("Project");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal>("TotalAmount");

                    b.Property<bool>("Type");

                    b.HasKey("Id");

                    b.ToTable("BudgetCodes","User");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .HasMaxLength(75);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Categories","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.CFO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id", "EmployeeId", "DateAdded");

                    b.HasAlternateKey("DateAdded", "EmployeeId", "Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("Id");

                    b.ToTable("CFOs","User");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.CFOApproval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApprovalId");

                    b.Property<int>("CFOId");

                    b.Property<string>("DeniedJustification");

                    b.Property<int>("OrderId");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("ApprovalId");

                    b.HasIndex("CFOId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("CFOApprovals","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("DepartmentName");

                    b.Property<int>("DivisionId");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("Departments","User");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("DivisionName");

                    b.Property<int?>("ParentId");

                    b.Property<string>("SupervisorId");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("SupervisorId")
                        .IsUnique()
                        .HasFilter("[SupervisorId] IS NOT NULL");

                    b.ToTable("Divisions","User");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.EmployeesBudgetCodes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BudgetCodeId");

                    b.Property<string>("EmployeeId");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("BudgetCodeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeesBudgetCodes","User");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("ItemName")
                        .HasMaxLength(50);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Items","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessJustification");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("DateMade")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("DateOrdered");

                    b.Property<bool>("Delivered");

                    b.Property<string>("EmployeeId");

                    b.Property<bool>("Ordered");

                    b.Property<bool>("StateContract");

                    b.Property<int>("StatusId");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Chosen");

                    b.Property<decimal>("EstimatedCost");

                    b.Property<decimal>("EstimatedTotal")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("[QuantityRequested] * [EstimatedCost]");

                    b.Property<int>("ItemId");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("PaidCost");

                    b.Property<decimal>("PaidTotal")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("[QuantityRequested] * [PaidCost]");

                    b.Property<int>("QuantityRequested");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("VendorId");

                    b.ToTable("Requests","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StatusName")
                        .HasMaxLength(50);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Statuses","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.SupervisorApproval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApprovalId");

                    b.Property<string>("DeniedJustification");

                    b.Property<int>("OrderId");

                    b.Property<string>("SupervisorId");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("ApprovalId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("SupervisorId");

                    b.ToTable("SupervisorApprovals","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("Fax")
                        .HasMaxLength(20);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("State")
                        .HasMaxLength(2);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("VendorName")
                        .HasMaxLength(20);

                    b.Property<string>("Website")
                        .HasMaxLength(20);

                    b.Property<string>("Zip")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Vendors","Order");
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Employee", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("Active");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees","User");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.AlternativeRequest", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Request", "Alternative")
                        .WithMany("RequestAlternative")
                        .HasForeignKey("AlternativeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Request", "Request")
                        .WithMany("AlternativeRequests")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Attachment", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Request", "Request")
                        .WithMany("Attachents")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.CFO", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Employee", "Employee")
                        .WithOne("CFO")
                        .HasForeignKey("PurchaseReq.Models.Entities.CFO", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.CFOApproval", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Approval", "Approval")
                        .WithMany()
                        .HasForeignKey("ApprovalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.CFO", "CFO")
                        .WithMany("CFOApprovals")
                        .HasForeignKey("CFOId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Order", "Order")
                        .WithOne("CFOApproval")
                        .HasForeignKey("PurchaseReq.Models.Entities.CFOApproval", "OrderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Department", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Division", "Division")
                        .WithMany("Departments")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Division", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Division", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Employee", "Supervisor")
                        .WithOne("SupervisedDivision")
                        .HasForeignKey("PurchaseReq.Models.Entities.Division", "SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.EmployeesBudgetCodes", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.BudgetCode", "BudgetCode")
                        .WithMany("EmployeesBudgetCode")
                        .HasForeignKey("BudgetCodeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Employee", "Employee")
                        .WithMany("EmployeesBudgetCode")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Order", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Category", "Category")
                        .WithMany("Orders")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Request", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Item", "Item")
                        .WithMany("Requests")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Order", "Order")
                        .WithMany("Requests")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Vendor", "Vendor")
                        .WithMany("Requests")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.SupervisorApproval", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Approval", "Approval")
                        .WithMany("SupervisorApprovals")
                        .HasForeignKey("ApprovalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Order", "Order")
                        .WithOne("SupervisorApproval")
                        .HasForeignKey("PurchaseReq.Models.Entities.SupervisorApproval", "OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PurchaseReq.Models.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PurchaseReq.Models.Entities.Employee", b =>
                {
                    b.HasOne("PurchaseReq.Models.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
