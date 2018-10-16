using Microsoft.EntityFrameworkCore.Migrations;

namespace Clay.WebApi.Migrations
{
    public partial class IdentifierAddedInLock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Locks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Locks");
        }
    }
}
