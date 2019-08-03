using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelBeds.Client.Data.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Holders_HolderId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Holders");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_HolderId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "HolderId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "HolderName",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HolderSurname",
                table: "Bookings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HolderName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "HolderSurname",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "HolderId",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Holders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HolderId",
                table: "Bookings",
                column: "HolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Holders_HolderId",
                table: "Bookings",
                column: "HolderId",
                principalTable: "Holders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
