using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "payment_details",
                schema: "public",
                columns: table => new
                {
                    payment_details_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    card_owner_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    card_number = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    expiration_date = table.Column<DateOnly>(type: "date", nullable: false),
                    cvv = table.Column<long>(type: "bigint", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_details", x => x.payment_details_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_details",
                schema: "public");
        }
    }
}
