using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristTourGuide.Data.Migrations
{
    /// <inheritdoc />
    public partial class addPhoneNumberColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 20, 6, 34, 712, DateTimeKind.Utc).AddTicks(6177),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "GuideUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "GuideUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 31, 20, 6, 34, 712, DateTimeKind.Utc).AddTicks(6177));
        }
    }
}
