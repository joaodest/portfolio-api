using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portfolio_api.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiencias_TimePeriods_DateEndedTimePeriodId",
                table: "Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiencias_TimePeriods_DateStartedTimePeriodId",
                table: "Experiencias");

            migrationBuilder.DropIndex(
                name: "IX_Experiencias_DateEndedTimePeriodId",
                table: "Experiencias");

            migrationBuilder.DropIndex(
                name: "IX_Experiencias_DateStartedTimePeriodId",
                table: "Experiencias");

            migrationBuilder.DropColumn(
                name: "EndedMonth",
                table: "TimePeriods");

            migrationBuilder.DropColumn(
                name: "EndedYear",
                table: "TimePeriods");

            migrationBuilder.DropColumn(
                name: "StartedMonth",
                table: "TimePeriods");

            migrationBuilder.DropColumn(
                name: "StartedYear",
                table: "TimePeriods");

            migrationBuilder.DropColumn(
                name: "DateEndedTimePeriodId",
                table: "Experiencias");

            migrationBuilder.DropColumn(
                name: "DateStartedTimePeriodId",
                table: "Experiencias");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "TimePeriods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "TimePeriods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DateEnded",
                table: "Experiencias",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateStarted",
                table: "Experiencias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_TimePeriodId",
                table: "Experiencias",
                column: "TimePeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiencias_TimePeriods_TimePeriodId",
                table: "Experiencias",
                column: "TimePeriodId",
                principalTable: "TimePeriods",
                principalColumn: "TimePeriodId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiencias_TimePeriods_TimePeriodId",
                table: "Experiencias");

            migrationBuilder.DropIndex(
                name: "IX_Experiencias_TimePeriodId",
                table: "Experiencias");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "TimePeriods");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "TimePeriods");

            migrationBuilder.DropColumn(
                name: "DateEnded",
                table: "Experiencias");

            migrationBuilder.DropColumn(
                name: "DateStarted",
                table: "Experiencias");

            migrationBuilder.AddColumn<string>(
                name: "EndedMonth",
                table: "TimePeriods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndedYear",
                table: "TimePeriods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartedMonth",
                table: "TimePeriods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartedYear",
                table: "TimePeriods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DateEndedTimePeriodId",
                table: "Experiencias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DateStartedTimePeriodId",
                table: "Experiencias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_DateEndedTimePeriodId",
                table: "Experiencias",
                column: "DateEndedTimePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencias_DateStartedTimePeriodId",
                table: "Experiencias",
                column: "DateStartedTimePeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiencias_TimePeriods_DateEndedTimePeriodId",
                table: "Experiencias",
                column: "DateEndedTimePeriodId",
                principalTable: "TimePeriods",
                principalColumn: "TimePeriodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiencias_TimePeriods_DateStartedTimePeriodId",
                table: "Experiencias",
                column: "DateStartedTimePeriodId",
                principalTable: "TimePeriods",
                principalColumn: "TimePeriodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
