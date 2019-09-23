using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Calculator.Repository.Migrations
{
    public partial class AddApplicationDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculationHistories_ApplicationUser_ApplicationUserId",
                table: "CalculationHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "ApplicationUsers");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_UserName",
                table: "ApplicationUsers",
                newName: "IX_ApplicationUsers_UserName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ApplicationUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 23, 10, 48, 53, 654, DateTimeKind.Utc).AddTicks(6324),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 23, 9, 16, 43, 501, DateTimeKind.Utc).AddTicks(8732));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalculationHistories_ApplicationUsers_ApplicationUserId",
                table: "CalculationHistories",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculationHistories_ApplicationUsers_ApplicationUserId",
                table: "CalculationHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers");

            migrationBuilder.RenameTable(
                name: "ApplicationUsers",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsers_UserName",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_UserName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ApplicationUser",
                nullable: false,
                defaultValue: new DateTime(2019, 9, 23, 9, 16, 43, 501, DateTimeKind.Utc).AddTicks(8732),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 9, 23, 10, 48, 53, 654, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalculationHistories_ApplicationUser_ApplicationUserId",
                table: "CalculationHistories",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
