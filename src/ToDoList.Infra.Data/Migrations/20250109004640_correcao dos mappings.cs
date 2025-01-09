using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class correcaodosmappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentList_Assignments_AssignmentId",
                table: "AssignmentList");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentList_User_UserId",
                table: "AssignmentList");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AssignmentList_AssignmentListId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentList_AssignmentId",
                table: "AssignmentList");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "AssignmentList");

            migrationBuilder.AlterColumn<bool>(
                name: "IsConcluded",
                table: "Assignments",
                type: "TINYINT(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "TINYINT(1)");

            migrationBuilder.AddColumn<long>(
                name: "AssignmentListId1",
                table: "Assignments",
                type: "BIGINT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Assignments",
                type: "DATETIME",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Assignments",
                type: "DATETIME",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentListId1",
                table: "Assignments",
                column: "AssignmentListId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentList_User_UserId",
                table: "AssignmentList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AssignmentList_AssignmentListId",
                table: "Assignments",
                column: "AssignmentListId",
                principalTable: "AssignmentList",
                principalColumn: "IdAssignmentList",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AssignmentList_AssignmentListId1",
                table: "Assignments",
                column: "AssignmentListId1",
                principalTable: "AssignmentList",
                principalColumn: "IdAssignmentList");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_User_UserId",
                table: "Assignments",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentList_User_UserId",
                table: "AssignmentList");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AssignmentList_AssignmentListId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AssignmentList_AssignmentListId1",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_User_UserId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_AssignmentListId1",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AssignmentListId1",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Assignments");

            migrationBuilder.AlterColumn<bool>(
                name: "IsConcluded",
                table: "Assignments",
                type: "TINYINT(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "TINYINT(1)",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "AssignmentId",
                table: "AssignmentList",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentList_AssignmentId",
                table: "AssignmentList",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentList_Assignments_AssignmentId",
                table: "AssignmentList",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentList_User_UserId",
                table: "AssignmentList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AssignmentList_AssignmentListId",
                table: "Assignments",
                column: "AssignmentListId",
                principalTable: "AssignmentList",
                principalColumn: "IdAssignmentList",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
