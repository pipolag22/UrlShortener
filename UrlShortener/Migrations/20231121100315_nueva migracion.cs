using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UrlShortener.Migrations
{
    /// <inheritdoc />
    public partial class nuevamigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "URLs",
                columns: new[] { "Id", "IdCategoria", "IdUser", "UrlLong", "UrlShort", "contador" },
                values: new object[,]
                {
                    { 1, 2, 1, "sadSaD1f", "www.google.com.ar", 0 },
                    { 2, 1, 2, "as9f9pa3rmf", "www.elbananero.com", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "URLs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "URLs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
