using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starcatcher.Api.Migrations
{
    /// <inheritdoc />
    public partial class QuotaUserIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotas_Users_UserId",
                table: "Quotas");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Quotas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Consortia",
                keyColumn: "ConsortiumId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 22, 27, 46, 66, DateTimeKind.Local).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "Consortia",
                keyColumn: "ConsortiumId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 22, 27, 46, 66, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "Consortia",
                keyColumn: "ConsortiumId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 22, 27, 46, 66, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.AddForeignKey(
                name: "FK_Quotas_Users_UserId",
                table: "Quotas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotas_Users_UserId",
                table: "Quotas");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Quotas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Consortia",
                keyColumn: "ConsortiumId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 22, 21, 20, 761, DateTimeKind.Local).AddTicks(185));

            migrationBuilder.UpdateData(
                table: "Consortia",
                keyColumn: "ConsortiumId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 22, 21, 20, 761, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "Consortia",
                keyColumn: "ConsortiumId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 22, 21, 20, 761, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.AddForeignKey(
                name: "FK_Quotas_Users_UserId",
                table: "Quotas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
