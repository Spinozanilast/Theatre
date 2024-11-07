using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theatre.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicatingDataFromTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Sectors_SectorId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SectorId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "Unique_Ticket",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RowNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Tickets");

            migrationBuilder.AddColumn<int[]>(
                name: "SeatIds",
                table: "Tickets",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.CreateIndex(
                name: "Unique_Ticket",
                table: "Tickets",
                columns: new[] { "EventId", "UserId", "HallId", "SeatIds" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Unique_Ticket",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatIds",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "RowNumber",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SectorId",
                table: "Tickets",
                column: "SectorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique_Ticket",
                table: "Tickets",
                columns: new[] { "EventId", "UserId", "HallId", "SectorId", "RowNumber", "SeatNumber" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Sectors_SectorId",
                table: "Tickets",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
