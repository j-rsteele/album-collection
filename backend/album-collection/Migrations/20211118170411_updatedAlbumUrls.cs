using Microsoft.EntityFrameworkCore.Migrations;

namespace album_collection.Migrations
{
    public partial class updatedAlbumUrls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "/images/kevingates.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "/images.kevingates.jpeg");
        }
    }
}
