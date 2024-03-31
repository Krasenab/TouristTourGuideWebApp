using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristTourGuide.Data.Migrations
{
    /// <inheritdoc />
    public partial class justMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 23, 25, 49, 346, DateTimeKind.Utc).AddTicks(2262),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 31, 23, 15, 54, 178, DateTimeKind.Utc).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "TouristsTours",
                keyColumn: "Id",
                keyValue: new Guid("f4e0c782-d1a4-42d1-9182-90b6fb2935e4"),
                columns: new[] { "CreatedOn", "LocationId" },
                values: new object[] { new DateTime(2024, 3, 31, 23, 25, 49, 346, DateTimeKind.Utc).AddTicks(2262), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 23, 15, 54, 178, DateTimeKind.Utc).AddTicks(1577),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 31, 23, 25, 49, 346, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "TouristsTours",
                keyColumn: "Id",
                keyValue: new Guid("f4e0c782-d1a4-42d1-9182-90b6fb2935e4"),
                columns: new[] { "CreatedOn", "LocationId" },
                values: new object[] { new DateTime(2024, 3, 31, 23, 15, 54, 178, DateTimeKind.Utc).AddTicks(1577), null });
        }
    }
}
