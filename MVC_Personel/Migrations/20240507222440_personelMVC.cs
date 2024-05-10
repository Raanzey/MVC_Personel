using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Personel.Migrations
{
    public partial class personelMVC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kullanici = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    Sifre = table.Column<string>(type: "Varchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "Varchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Birims",
                columns: table => new
                {
                    BirimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birims", x => x.BirimID);
                });

            migrationBuilder.CreateTable(
                name: "PersonelBilgis",
                columns: table => new
                {
                    PersonelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: false),
                    Soyad = table.Column<string>(nullable: false),
                    Sehir = table.Column<string>(nullable: false),
                    BirimID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelBilgis", x => x.PersonelID);
                    table.ForeignKey(
                        name: "FK_PersonelBilgis_Birims_BirimID",
                        column: x => x.BirimID,
                        principalTable: "Birims",
                        principalColumn: "BirimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelBilgis_BirimID",
                table: "PersonelBilgis",
                column: "BirimID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "PersonelBilgis");

            migrationBuilder.DropTable(
                name: "Birims");
        }
    }
}
