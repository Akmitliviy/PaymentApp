using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "cvv",
                schema: "public",
                table: "payment_details",
                type: "integer",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "cvv",
                schema: "public",
                table: "payment_details",
                type: "bigint",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 3);
        }
    }
}
