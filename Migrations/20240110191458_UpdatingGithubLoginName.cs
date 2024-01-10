using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portfolio_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingGithubLoginName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "ExperienciaId",
                table: "LinkedInUsers");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "GithubUsers",
                newName: "Username");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "GithubUsers",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "Experiencia",
                table: "Experiencias",
                newName: "LinkedInUserUserId");

        }
    }
}
