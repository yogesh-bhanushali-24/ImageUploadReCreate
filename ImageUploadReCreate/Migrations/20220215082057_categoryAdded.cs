using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageUploadReCreate.Migrations
{
    public partial class categoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stdcategories",
                columns: table => new
                {
                    Cid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stdcategories", x => x.Cid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stdcategories");
        }
    }
}
