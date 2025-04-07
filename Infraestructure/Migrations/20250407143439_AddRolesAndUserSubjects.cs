using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesAndUserSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nchar(50)",
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nchar(50)",
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "IdRole",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleIdRole",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                type: "nchar(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "UserSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubjects_Subjects",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSubjects_Users",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleIdRole",
                table: "Users",
                column: "RoleIdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubjects_IdSubject",
                table: "UserSubjects",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubjects_IdUser",
                table: "UserSubjects",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleIdRole",
                table: "Users",
                column: "RoleIdRole",
                principalTable: "Roles",
                principalColumn: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleIdRole",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleIdRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleIdRole",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(50)",
                oldFixedLength: true,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(50)",
                oldFixedLength: true,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(30)",
                oldFixedLength: true,
                oldMaxLength: 30);
        }
    }
}
