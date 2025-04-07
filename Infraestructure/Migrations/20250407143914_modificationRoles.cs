using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class modificationRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleIdRole",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleIdRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleIdRole",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleIdRole",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleIdRole",
                table: "Users",
                column: "RoleIdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleIdRole",
                table: "Users",
                column: "RoleIdRole",
                principalTable: "Roles",
                principalColumn: "IdRole");
        }
    }
}
