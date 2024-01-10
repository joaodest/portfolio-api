using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portfolio_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingUserTables_v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FistName",
                table: "LinkedInUsers",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "LinkedInUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExperienciaId",
                table: "Organisations",
                type: "integer",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "ExperienciaId",
                table: "LinkedInUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Experiencias",
                type: "integer",
                nullable: false,
                defaultValue: 2);


            migrationBuilder.AddForeignKey(
                name: "FK_Experiencias_LinkedInUsers_UserId",
                table: "Experiencias",
                column: "UserId",
                principalTable: "LinkedInUsers",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiencias_LinkedInUsers_UserId",
                table: "Experiencias");

            migrationBuilder.DropColumn(
                name: "ExperienciaId",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "ExperienciaId",
                table: "LinkedInUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Experiencias");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LinkedInUsers",
                newName: "FirstName");
        }
    }
}
