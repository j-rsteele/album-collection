using Microsoft.EntityFrameworkCore.Migrations;

namespace album_collection.Migrations
{
    public partial class UpdatedArtistandReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "recordLabel",
                value: "EMI");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "recordLabel",
                value: "Bread Winners Association");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "Hometown", "imageUrl", "recordLabel" },
                values: new object[] { 57, "Minnesota", "/images/princeartist.jfif", "Columbia Records" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "Hometown", "imageUrl", "recordLabel" },
                values: new object[] { 48, "Sydney", "/images/ACDCbetter.jpeg", "" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "Hometown", "imageUrl", "recordLabel" },
                values: new object[] { 35, "Louisiana", "/images/profile.png", "Bread Winners Association" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Amazing album.. One of a kind");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Whole albums a classic");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "Incredible beats to every song");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "recordLabel",
                value: "Atlantic Records");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "recordLabel",
                value: "Atlantic Records");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "Hometown", "imageUrl", "recordLabel" },
                values: new object[] { 50, "Akron", "", "Atlantic Records" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "Hometown", "imageUrl", "recordLabel" },
                values: new object[] { 50, "Akron", "", "Atlantic Records" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "Hometown", "imageUrl", "recordLabel" },
                values: new object[] { 50, "Akron", "", "Atlantic Records" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Nunc aliquet bibendum enim facilisis. Tellus orci ac auctor augue mauris augue neque. Massa ultricies mi quis hendrerit do");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Nunc aliquet bibendum enim facilisis. Tellus orci ac auctor augue mauris augue neque. Massa ultricies mi quis hendrerit do");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "Nunc aliquet bibendum enim facilisis. Tellus orci ac auctor augue mauris augue neque. Massa ultricies mi quis hendrerit do");
        }
    }
}
