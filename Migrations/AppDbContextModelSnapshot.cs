﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using portfolio_api.Data;

#nullable disable

namespace portfolio_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Experiencia", b =>
                {
                    b.Property<int>("ExperienciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExperienciaId"));

                    b.Property<string>("DateEnded")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "dateEnded");

                    b.Property<string>("DateStarted")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "dateStarted");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<int?>("LinkedInUserUserId")
                        .HasColumnType("integer");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("integer");

                    b.Property<int>("TimePeriodId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "title");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ExperienciaId");

                    b.HasIndex("LinkedInUserUserId");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("TimePeriodId");

                    b.ToTable("Experiencias");

                    b.HasAnnotation("Relational:JsonPropertyName", "experience");
                });

            modelBuilder.Entity("TimePeriod", b =>
                {
                    b.Property<int>("TimePeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TimePeriodId"));

                    b.Property<int>("ExperienciaId")
                        .HasColumnType("integer");

                    b.Property<int>("Month")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("TimePeriodId");

                    b.ToTable("TimePeriods");
                });

            modelBuilder.Entity("portfolio_api.Models.GithubModels.FeaturedProjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("boolean")
                        .HasAnnotation("Relational:JsonPropertyName", "private");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "html_url");

                    b.HasKey("Id");

                    b.ToTable("FeaturedProjects");
                });

            modelBuilder.Entity("portfolio_api.Models.GithubModels.GithubUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarURL")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "avatar_url");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "login");

                    b.Property<string>("ProfileURL")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "html_url");

                    b.HasKey("Id");

                    b.ToTable("GithubUsers");
                });

            modelBuilder.Entity("portfolio_api.Models.LinkedinModels.LinkedInUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("FistName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("Headline")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "link");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "aboutSummaryText");

                    b.HasKey("UserId");

                    b.ToTable("LinkedInUsers");
                });

            modelBuilder.Entity("portfolio_api.Models.LinkedinModels.Organisation", b =>
                {
                    b.Property<int>("OrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrganisationId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrganisationId");

                    b.ToTable("Organisations");

                    b.HasAnnotation("Relational:JsonPropertyName", "organisation");
                });

            modelBuilder.Entity("Experiencia", b =>
                {
                    b.HasOne("portfolio_api.Models.LinkedinModels.LinkedInUser", null)
                        .WithMany("Experiences")
                        .HasForeignKey("LinkedInUserUserId");

                    b.HasOne("portfolio_api.Models.LinkedinModels.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimePeriod", "TimePeriod")
                        .WithMany()
                        .HasForeignKey("TimePeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");

                    b.Navigation("TimePeriod");
                });

            modelBuilder.Entity("portfolio_api.Models.LinkedinModels.LinkedInUser", b =>
                {
                    b.Navigation("Experiences");
                });
#pragma warning restore 612, 618
        }
    }
}
