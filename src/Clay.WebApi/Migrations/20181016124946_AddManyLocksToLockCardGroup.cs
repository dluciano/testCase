using Microsoft.EntityFrameworkCore.Migrations;

namespace Clay.WebApi.Migrations
{
    public partial class AddManyLocksToLockCardGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardGroupLocks_Locks_LockId",
                table: "CardGroupLocks");

            migrationBuilder.DropIndex(
                name: "IX_CardGroupLocks_LockId",
                table: "CardGroupLocks");

            migrationBuilder.DropColumn(
                name: "LockId",
                table: "CardGroupLocks");

            migrationBuilder.AddColumn<int>(
                name: "CardGroupLockId",
                table: "Locks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locks_CardGroupLockId",
                table: "Locks",
                column: "CardGroupLockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locks_CardGroupLocks_CardGroupLockId",
                table: "Locks",
                column: "CardGroupLockId",
                principalTable: "CardGroupLocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locks_CardGroupLocks_CardGroupLockId",
                table: "Locks");

            migrationBuilder.DropIndex(
                name: "IX_Locks_CardGroupLockId",
                table: "Locks");

            migrationBuilder.DropColumn(
                name: "CardGroupLockId",
                table: "Locks");

            migrationBuilder.AddColumn<int>(
                name: "LockId",
                table: "CardGroupLocks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardGroupLocks_LockId",
                table: "CardGroupLocks",
                column: "LockId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardGroupLocks_Locks_LockId",
                table: "CardGroupLocks",
                column: "LockId",
                principalTable: "Locks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
