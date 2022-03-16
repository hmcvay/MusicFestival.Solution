﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicFestival.Models;

namespace MusicFestival.Migrations
{
    [DbContext(typeof(MusicFestivalContext))]
    [Migration("20220316173346_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MusicFestival.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MusicFestival.Models.Stage", b =>
                {
                    b.Property<int>("StageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("StageId");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("MusicFestival.Models.StageArtist", b =>
                {
                    b.Property<int>("StageArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.HasKey("StageArtistId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("StageId");

                    b.ToTable("StageArtist");
                });

            modelBuilder.Entity("MusicFestival.Models.StageArtist", b =>
                {
                    b.HasOne("MusicFestival.Models.Artist", "Artist")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicFestival.Models.Stage", "Stage")
                        .WithMany("JoinEntities")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("MusicFestival.Models.Artist", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("MusicFestival.Models.Stage", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
