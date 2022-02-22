using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageUploadReCreate.Migrations
{
    public partial class Customerproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Custid",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "customers");

            migrationBuilder.AddColumn<int>(
                name: "Pid",
                table: "customers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Pdetail",
                table: "customers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pname",
                table: "customers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Pprice",
                table: "customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "customers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Pid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Pid",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Pdetail",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Pname",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Pprice",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "customers");

            migrationBuilder.AddColumn<int>(
                name: "Custid",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Custid");
        }
    }
}
