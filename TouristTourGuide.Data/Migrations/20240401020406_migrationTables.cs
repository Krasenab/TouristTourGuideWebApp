using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristTourGuide.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 1, 2, 4, 5, 832, DateTimeKind.Utc).AddTicks(9719),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 1, 1, 26, 4, 347, DateTimeKind.Utc).AddTicks(3846));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 1, 1, 26, 4, 347, DateTimeKind.Utc).AddTicks(3846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 1, 2, 4, 5, 832, DateTimeKind.Utc).AddTicks(9719));
        }
    }
}
