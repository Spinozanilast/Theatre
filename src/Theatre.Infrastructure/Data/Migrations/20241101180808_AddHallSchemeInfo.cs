using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theatre.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHallSchemeInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchemeGridColumnsCount",
                table: "Halls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SchemeGridRowsCount",
                table: "Halls",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchemeGridColumnsCount",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "SchemeGridRowsCount",
                table: "Halls");
        }
    }
}
