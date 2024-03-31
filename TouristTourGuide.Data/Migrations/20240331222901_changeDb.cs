using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristTourGuide.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NotSuitableFor",
                table: "TouristsTours",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Highlights",
                table: "TouristsTours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 22, 29, 1, 190, DateTimeKind.Utc).AddTicks(8880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 31, 22, 12, 36, 584, DateTimeKind.Utc).AddTicks(294));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NotSuitableFor",
                table: "TouristsTours",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Highlights",
                table: "TouristsTours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 22, 12, 36, 584, DateTimeKind.Utc).AddTicks(294),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 31, 22, 29, 1, 190, DateTimeKind.Utc).AddTicks(8880));
        }
    }
}
