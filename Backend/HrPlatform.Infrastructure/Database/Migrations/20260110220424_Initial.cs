using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrPlatform.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HrPlatform");

            migrationBuilder.CreateTable(
                name: "Persistence",
                schema: "HrPlatform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersistenceCode = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persistence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "HrPlatform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "HrPlatform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "HrPlatform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Position_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "HrPlatform",
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePersistence",
                schema: "HrPlatform",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersistenceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePersistence", x => new { x.RoleId, x.PersistenceId });
                    table.ForeignKey(
                        name: "FK_RolePersistence_Persistence_PersistenceId",
                        column: x => x.PersistenceId,
                        principalSchema: "HrPlatform",
                        principalTable: "Persistence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePersistence_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "HrPlatform",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "HrPlatform",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "HrPlatform",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "HrPlatform",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persistence_PersistenceCode",
                schema: "HrPlatform",
                table: "Persistence",
                column: "PersistenceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePersistence_PersistenceId",
                schema: "HrPlatform",
                table: "RolePersistence",
                column: "PersistenceId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PositionId",
                schema: "HrPlatform",
                table: "User",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "HrPlatform",
                table: "UserRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePersistence",
                schema: "HrPlatform");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "HrPlatform");

            migrationBuilder.DropTable(
                name: "Persistence",
                schema: "HrPlatform");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "HrPlatform");

            migrationBuilder.DropTable(
                name: "User",
                schema: "HrPlatform");

            migrationBuilder.DropTable(
                name: "Position",
                schema: "HrPlatform");
        }
    }
}
