using Microsoft.EntityFrameworkCore.Migrations;

namespace Clay.WebApi.Migrations
{
    public partial class AddOwnerUserNameInProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerUsername",
                table: "Properties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerUsername",
                table: "Properties");
        }
    }
}
