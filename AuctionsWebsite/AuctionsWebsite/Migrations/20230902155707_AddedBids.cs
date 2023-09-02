using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionsWebsite.Migrations
{
    public partial class AddedBids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auction_User_UserId",
                table: "Auction");

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bid_Auction_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bid_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bid_AuctionId",
                table: "Bid",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_UserId",
                table: "Bid",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auction_User_UserId",
                table: "Auction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auction_User_UserId",
                table: "Auction");

            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.AddForeignKey(
                name: "FK_Auction_User_UserId",
                table: "Auction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
