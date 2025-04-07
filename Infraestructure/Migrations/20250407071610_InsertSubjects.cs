using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new TestInterContext(new DbContextOptionsBuilder<TestInterContext>()
                .UseSqlServer("Server=LAPTOP-ERUIZ;Database=TestInterRapidisimo;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options);

            if (!context.Subjects.Any())
            {

                var subjects = new object[,]
                {
                    { Guid.NewGuid(), "Mathematics", "MATH101" },
                    { Guid.NewGuid(), "Physics", "PHYS101" },
                    { Guid.NewGuid(), "Chemistry", "CHEM101" },
                    { Guid.NewGuid(), "Biology", "BIO101" },
                    { Guid.NewGuid(), "History", "HIST101" },
                    { Guid.NewGuid(), "Geography", "GEO101" },
                    { Guid.NewGuid(), "English", "ENG101" },
                    { Guid.NewGuid(), "Spanish", "SPA101" },
                    { Guid.NewGuid(), "Computer Science", "CS101" },
                    { Guid.NewGuid(), "Art", "ART101" },
                };

                migrationBuilder.InsertData(
                    table: "Subjects",
                    columns: new[] { "Id", "Name", "Code" },
                    values: subjects);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
