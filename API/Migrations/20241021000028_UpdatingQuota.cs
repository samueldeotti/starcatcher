using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Starcatcher.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingQuota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Quotas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Quotas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Quotas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Consortia",
                columns: new[] { "ConsortiumId", "ClosedAt", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 10, 20, 21, 0, 27, 255, DateTimeKind.Local).AddTicks(5481), "Consórcio para aquisição de veículos", "Consórcio de Carros" },
                    { 2, null, new DateTime(2024, 10, 20, 21, 0, 27, 255, DateTimeKind.Local).AddTicks(5498), "Consórcio para aquisição de imóveis", "Consórcio de Imóveis" },
                    { 3, null, new DateTime(2024, 10, 20, 21, 0, 27, 255, DateTimeKind.Local).AddTicks(5513), "Consórcio para aquisição de motocicletas", "Consórcio de Motos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consortia",
                keyColumn: "ConsortiumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Consortia",
                keyColumn: "ConsortiumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Consortia",
                keyColumn: "ConsortiumId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Quotas");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Quotas");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Quotas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
