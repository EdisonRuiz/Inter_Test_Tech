using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new TestInterContext(new DbContextOptionsBuilder<TestInterContext>()
                .UseSqlServer("Server=LAPTOP-ERUIZ;Database=TestInterRapidisimo;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options);

            if (!context.Users.Any())
            {
                var teachers = new object[,]
                {
                    { Guid.NewGuid().ToString(), "Teacher 1", "teacher1@gmail.com", DateTime.Now, 2 },
                    { Guid.NewGuid().ToString(), "Teacher 2", "teacher2@gmail.com", DateTime.Now, 2 },
                    { Guid.NewGuid().ToString(), "Teacher 3", "teacher3@gmail.com", DateTime.Now, 2 },
                    { Guid.NewGuid().ToString(), "Teacher 4", "teacher4@gmail.com", DateTime.Now, 2 },
                    { Guid.NewGuid().ToString(), "Teacher 5", "teacher5@gmail.com", DateTime.Now, 2 }
                };
                migrationBuilder.InsertData(
                    table: "Users",
                    columns: new[] { "IdUser", "Name", "Email", "EnrollmentDate", "IdRole" },
                    values: teachers);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
