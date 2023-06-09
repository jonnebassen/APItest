﻿// <auto-generated />
using BouvetAPI.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BouvetAPI.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("BouvetAPI.Models.Epic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Epics");
                });

            modelBuilder.Entity("BouvetAPI.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BouvetAPI.Models.Worktask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("EpicId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Responsible")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EpicId");

                    b.ToTable("Worktasks");
                });

            modelBuilder.Entity("BouvetAPI.Models.Epic", b =>
                {
                    b.HasOne("BouvetAPI.Models.Project", null)
                        .WithMany("Epics")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BouvetAPI.Models.Worktask", b =>
                {
                    b.HasOne("BouvetAPI.Models.Epic", null)
                        .WithMany("Worktasks")
                        .HasForeignKey("EpicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BouvetAPI.Models.Epic", b =>
                {
                    b.Navigation("Worktasks");
                });

            modelBuilder.Entity("BouvetAPI.Models.Project", b =>
                {
                    b.Navigation("Epics");
                });
#pragma warning restore 612, 618
        }
    }
}
