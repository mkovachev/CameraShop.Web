using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CameraShop.Data.Migrations
{
    public partial class CameraTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 6000, nullable: true),
                    ImageURL = table.Column<int>(type: "int", nullable: false),
                    IsFullFrame = table.Column<bool>(type: "bit", nullable: false),
                    LightMetering = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<int>(type: "int", nullable: false),
                    MaxISO = table.Column<byte>(type: "tinyint", nullable: false),
                    MaxShutterSpeed = table.Column<int>(type: "int", nullable: false),
                    MinISO = table.Column<byte>(type: "tinyint", nullable: false),
                    MinShutterSpeed = table.Column<byte>(type: "tinyint", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    VideoResolution = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cameras");
        }
    }
}
