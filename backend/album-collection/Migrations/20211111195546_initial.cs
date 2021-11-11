using Microsoft.EntityFrameworkCore.Migrations;

namespace album_collection.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    recordLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hometown = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    artistId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recordLabel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_artistId",
                        column: x => x.artistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    albumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_albumId",
                        column: x => x.albumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Age", "Hometown", "Name", "imageUrl", "recordLabel" },
                values: new object[] { 1, 50, "Akron", "Prince", "", "Atlantic Records" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Age", "Hometown", "Name", "imageUrl", "recordLabel" },
                values: new object[] { 2, 50, "Akron", "AC/DC", "", "Atlantic Records" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Age", "Hometown", "Name", "imageUrl", "recordLabel" },
                values: new object[] { 3, 50, "Akron", "Kevin Gates", "", "Atlantic Records" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Image", "Title", "artistId", "recordLabel" },
                values: new object[] { 1, "", "Paisley Park", 1, "Atlantic Records" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Image", "Title", "artistId", "recordLabel" },
                values: new object[] { 2, "", "Highway to Hell", 2, "Atlantic Records" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Image", "Title", "artistId", "recordLabel" },
                values: new object[] { 3, "", "Isaiah", 3, "Atlantic Records" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AlbumId", "Content", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Nunc aliquet bibendum enim facilisis. Tellus orci ac auctor augue mauris augue neque. Massa ultricies mi quis hendrerit do", "Joe Blow" },
                    { 2, 2, "Nunc aliquet bibendum enim facilisis. Tellus orci ac auctor augue mauris augue neque. Massa ultricies mi quis hendrerit do", "Seymour Butts" },
                    { 3, 3, "Nunc aliquet bibendum enim facilisis. Tellus orci ac auctor augue mauris augue neque. Massa ultricies mi quis hendrerit do", "Joseph Maninng" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Title", "albumId" },
                values: new object[,]
                {
                    { 1, "Paisley Park", 1 },
                    { 2, "Highway to Hell", 2 },
                    { 3, "Time for That", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_artistId",
                table: "Albums",
                column: "artistId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AlbumId",
                table: "Reviews",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_albumId",
                table: "Songs",
                column: "albumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
