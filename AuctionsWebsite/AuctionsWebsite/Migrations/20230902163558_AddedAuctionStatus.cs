using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionsWebsite.Migrations
{
    public partial class AddedAuctionStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Auction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Auction");
        }
    }
}
