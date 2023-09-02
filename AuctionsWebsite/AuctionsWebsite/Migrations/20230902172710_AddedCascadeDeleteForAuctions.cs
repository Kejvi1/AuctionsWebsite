using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionsWebsite.Migrations
{
    public partial class AddedCascadeDeleteForAuctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Auction_AuctionId",
                table: "Bid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Auction_AuctionId",
                table: "Bid",
                column: "AuctionId",
                principalTable: "Auction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Auction_AuctionId",
                table: "Bid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Auction_AuctionId",
                table: "Bid",
                column: "AuctionId",
                principalTable: "Auction",
                principalColumn: "Id");
        }
    }
}
