using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new TestInterContext(new DbContextOptionsBuilder<TestInterContext>()
                .UseSqlServer("Server=LAPTOP-ERUIZ;Database=TestInterRapidisimo;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options);

            if (!context.Roles.Any())
            {
                var roles = new object[,]
                {
                    { 1, "Student" },
                    { 2, "Teacher" },
                    { 3, "Admin" }
                };
                migrationBuilder.InsertData(
                    table: "Roles",
                    columns: new[] { "IdRole", "Name" },
                    values: roles);
            }           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
