using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionsWebsite.Migrations
{
    public partial class AddedUserIdToAuctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Auction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auction_UserId",
                table: "Auction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auction_User_UserId",
                table: "Auction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auction_User_UserId",
                table: "Auction");

            migrationBuilder.DropIndex(
                name: "IX_Auction_UserId",
                table: "Auction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Auction");
        }
    }
}
