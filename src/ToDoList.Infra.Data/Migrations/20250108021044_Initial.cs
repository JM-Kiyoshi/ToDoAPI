using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssignmentList",
                columns: table => new
                {
                    IdAssignmentList = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<long>(type: "BIGINT", nullable: false),
                    AssignmentId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentList", x => x.IdAssignmentList);
                    table.ForeignKey(
                        name: "FK_AssignmentList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "VARCHAR(500)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<long>(type: "BIGINT", nullable: false),
                    AssignmentListId = table.Column<long>(type: "BIGINT", nullable: false),
                    IsConcluded = table.Column<bool>(type: "TINYINT(1)", nullable: false),
                    ConcludedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Deadline = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_AssignmentList_AssignmentListId",
                        column: x => x.AssignmentListId,
                        principalTable: "AssignmentList",
                        principalColumn: "IdAssignmentList",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentList_AssignmentId",
                table: "AssignmentList",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentList_UserId",
                table: "AssignmentList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentListId",
                table: "Assignments",
                column: "AssignmentListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentList_Assignments_AssignmentId",
                table: "AssignmentList",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentList_Assignments_AssignmentId",
                table: "AssignmentList");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AssignmentList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
