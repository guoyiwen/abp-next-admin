﻿// <auto-generated />
using System;
using LY.MicroService.WebhooksManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;

#nullable disable

namespace LY.MicroService.WebhooksManagement.Migrations
{
    [DbContext(typeof(WebhooksManagementMigrationsDbContext))]
    [Migration("20220326030345_Add-Module-WebHooks-Management")]
    partial class AddModuleWebHooksManagement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.MySql)
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookEventRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<string>("Data")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("Data");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletionTime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<string>("WebhookName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("WebhookName");

                    b.HasKey("Id");

                    b.ToTable("WebhooksManagement_WebhookEvents", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookSendRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<string>("Response")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("Response");

                    b.Property<int?>("ResponseStatusCode")
                        .HasColumnType("int");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<Guid>("WebhookEventId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WebhookSubscriptionId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WebhookEventId")
                        .IsUnique();

                    b.ToTable("WebhooksManagement_WebhookSendAttempts", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookSubscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<string>("Headers")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("Headers");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("Secret");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)");

                    b.Property<string>("WebhookUri")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("WebhookUri");

                    b.Property<string>("Webhooks")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("Webhooks");

                    b.HasKey("Id");

                    b.ToTable("WebhooksManagement_WebhookSubscriptions", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookSendRecord", b =>
                {
                    b.HasOne("LINGYUN.Abp.WebhooksManagement.WebhookEventRecord", "WebhookEvent")
                        .WithOne()
                        .HasForeignKey("LINGYUN.Abp.WebhooksManagement.WebhookSendRecord", "WebhookEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WebhookEvent");
                });
#pragma warning restore 612, 618
        }
    }
}