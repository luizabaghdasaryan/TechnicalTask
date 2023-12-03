using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AddressBookApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "PhysicalAddress" },
                values: new object[,]
                {
                    { 1, "armen.grigoryan@example.com", "Armen", "Grigoryan", "+37491012345", "Street 1, Yerevan" },
                    { 2, "ani.harutyunyan@example.com", "Ani", "Harutyunyan", "+37491567890", null },
                    { 3, "anna.sargsyan@example.com", "Anna", "Sargsyan", "+37499321098", "Street 42, Gyumri" },
                    { 4, "sahak.sahakyan@example.com", "Sahak", "Sahakyan", "+37497654321", "Street 34, Vanadzor" },
                    { 5, "ani.sahakyan@example.com", "Ani", "Sahakyan", "+37494123456", "Street 34, Yerevan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
