using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clay.WebApi.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardOwners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditId = table.Column<int>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    UserStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardOwners_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identitfier = table.Column<string>(nullable: false),
                    AuditId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    AuditId = table.Column<int>(nullable: true),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardGroups",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    AuditId = table.Column<int>(nullable: true),
                    PropertyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardGroups_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardGroups_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    PropertyId = table.Column<long>(nullable: true),
                    AuditId = table.Column<int>(nullable: true),
                    LockState = table.Column<int>(nullable: false),
                    DoorState = table.Column<int>(nullable: false),
                    AutoLockAfter = table.Column<long>(nullable: false),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locks_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locks_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locks_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardGroupLocks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditId = table.Column<int>(nullable: true),
                    LockId = table.Column<long>(nullable: true),
                    CardGroupId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardGroupLocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardGroupLocks_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardGroupLocks_CardGroups_CardGroupId",
                        column: x => x.CardGroupId,
                        principalTable: "CardGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardGroupLocks_Locks_LockId",
                        column: x => x.LockId,
                        principalTable: "Locks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LockCards",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditId = table.Column<int>(nullable: true),
                    LockId = table.Column<long>(nullable: true),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LockCards_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockCards_Locks_LockId",
                        column: x => x.LockId,
                        principalTable: "Locks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LockEvents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LockId = table.Column<long>(nullable: false),
                    CardId = table.Column<int>(nullable: true),
                    CardOwnerWhenEventTriggerId = table.Column<int>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    EventType = table.Column<int>(nullable: false),
                    AuditId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LockEvents_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockEvents_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockEvents_CardOwners_CardOwnerWhenEventTriggerId",
                        column: x => x.CardOwnerWhenEventTriggerId,
                        principalTable: "CardOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockEvents_Locks_LockId",
                        column: x => x.LockId,
                        principalTable: "Locks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardGroupLocks_AuditId",
                table: "CardGroupLocks",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_CardGroupLocks_CardGroupId",
                table: "CardGroupLocks",
                column: "CardGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CardGroupLocks_LockId",
                table: "CardGroupLocks",
                column: "LockId");

            migrationBuilder.CreateIndex(
                name: "IX_CardGroups_AuditId",
                table: "CardGroups",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_CardGroups_PropertyId",
                table: "CardGroups",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_CardOwners_AuditId",
                table: "CardOwners",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AuditId",
                table: "Cards",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_LockCards_AuditId",
                table: "LockCards",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_LockCards_CardId",
                table: "LockCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_LockCards_LockId",
                table: "LockCards",
                column: "LockId");

            migrationBuilder.CreateIndex(
                name: "IX_LockEvents_AuditId",
                table: "LockEvents",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_LockEvents_CardId",
                table: "LockEvents",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_LockEvents_CardOwnerWhenEventTriggerId",
                table: "LockEvents",
                column: "CardOwnerWhenEventTriggerId");

            migrationBuilder.CreateIndex(
                name: "IX_LockEvents_LockId",
                table: "LockEvents",
                column: "LockId");

            migrationBuilder.CreateIndex(
                name: "IX_Locks_AuditId",
                table: "Locks",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Locks_CardId",
                table: "Locks",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Locks_PropertyId",
                table: "Locks",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AuditId",
                table: "Properties",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CardId",
                table: "Properties",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardGroupLocks");

            migrationBuilder.DropTable(
                name: "LockCards");

            migrationBuilder.DropTable(
                name: "LockEvents");

            migrationBuilder.DropTable(
                name: "CardGroups");

            migrationBuilder.DropTable(
                name: "CardOwners");

            migrationBuilder.DropTable(
                name: "Locks");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Audit");
        }
    }
}
