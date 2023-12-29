using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace portfolio_api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkedInUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Headline = table.Column<string>(type: "text", nullable: false),
                    FistName = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedInUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    OrganisationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.OrganisationId);
                });

            migrationBuilder.CreateTable(
                name: "TimePeriods",
                columns: table => new
                {
                    TimePeriodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExperienciaId = table.Column<int>(type: "integer", nullable: false),
                    StartedMonth = table.Column<string>(type: "text", nullable: false),
                    EndedMonth = table.Column<string>(type: "text", nullable: false),
                    StartedYear = table.Column<string>(type: "text", nullable: false),
                    EndedYear = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePeriods", x => x.TimePeriodId);
                });

            migrationBuilder.CreateTable(
                name: "Experiencias",
                columns: table => new
                {
                    ExperienciaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    TimePeriodId = table.Column<int>(type: "integer", nullable: false),
                    DateStartedTimePeriodId = table.Column<int>(type: "integer", nullable: false),
                    DateEndedTimePeriodId = table.Column<int>(type: "integer", nullable: false),
                    LinkedInUserUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencias", x => x.ExperienciaId);
                    table.ForeignKey(
                        name: "FK_Experiencias_LinkedInUsers_LinkedInUserUserId",
                        column: x => x.LinkedInUserUserId,
                        principalTable: "LinkedInUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Experiencias_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiencias_TimePeriods_DateEndedTimePeriodId",
                        column: x => x.DateEndedTimePeriodId,
                        principalTable: "TimePeriods",
                        principalColumn: "TimePeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiencias_TimePeriods_DateStartedTimePeriodId",
                        column: x => x.DateStartedTimePeriodId,
                        principalTable: "TimePeriods",
                        principalColumn: "TimePeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_DateEndedTimePeriodId",
                table: "Experiencias",
                column: "DateEndedTimePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_DateStartedTimePeriodId",
                table: "Experiencias",
                column: "DateStartedTimePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_LinkedInUserUserId",
                table: "Experiencias",
                column: "LinkedInUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_OrganisationId",
                table: "Experiencias",
                column: "OrganisationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiencias");

            migrationBuilder.DropTable(
                name: "LinkedInUsers");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropTable(
                name: "TimePeriods");
        }
    }
}
