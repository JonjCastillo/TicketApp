﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketApp.Models;

#nullable disable

namespace TicketApp.Migrations
{
    [DbContext(typeof(IssueContext))]
    [Migration("20240316224822_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TicketApp.Models.Issue", b =>
                {
                    b.Property<int>("issueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("issueID"), 1L, 1);

                    b.Property<string>("PriorityID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StatusID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("submitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ticketDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ticketEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ticketName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ticketTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("issueID");

                    b.HasIndex("PriorityID");

                    b.HasIndex("StatusID");

                    b.ToTable("Issues");

                    b.HasData(
                        new
                        {
                            issueID = 1,
                            PriorityID = "3",
                            StatusID = "1",
                            submitDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ticketDescription = "I can't log in to my account",
                            ticketEmail = "johndoe@mail.com",
                            ticketName = "John Doe",
                            ticketTitle = "Can't log in"
                        },
                        new
                        {
                            issueID = 2,
                            PriorityID = "2",
                            StatusID = "2",
                            submitDate = new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ticketDescription = "I can't access my email",
                            ticketEmail = "janedoe@mail.com",
                            ticketName = "Jane Doe",
                            ticketTitle = "Can't access my email"
                        },
                        new
                        {
                            issueID = 3,
                            PriorityID = "3",
                            StatusID = "3",
                            submitDate = new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ticketDescription = "I need to reset my password",
                            ticketEmail = "manmichael@mail.com",
                            ticketName = "Michael Man",
                            ticketTitle = "Password Reset"
                        });
                });

            modelBuilder.Entity("TicketApp.Models.Priority", b =>
                {
                    b.Property<string>("PriorityID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PriorityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriorityID");

                    b.ToTable("Priorities");

                    b.HasData(
                        new
                        {
                            PriorityID = "1",
                            PriorityName = "Low"
                        },
                        new
                        {
                            PriorityID = "2",
                            PriorityName = "Medium"
                        },
                        new
                        {
                            PriorityID = "3",
                            PriorityName = "High"
                        },
                        new
                        {
                            PriorityID = "4",
                            PriorityName = "Critical"
                        });
                });

            modelBuilder.Entity("TicketApp.Models.Status", b =>
                {
                    b.Property<string>("StatusID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusID");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusID = "1",
                            StatusName = "Open"
                        },
                        new
                        {
                            StatusID = "2",
                            StatusName = "In Progress"
                        },
                        new
                        {
                            StatusID = "3",
                            StatusName = "Closed"
                        },
                        new
                        {
                            StatusID = "4",
                            StatusName = "Resolved"
                        });
                });

            modelBuilder.Entity("TicketApp.Models.Issue", b =>
                {
                    b.HasOne("TicketApp.Models.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketApp.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Priority");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
