using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristTourGuide.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeDbNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WhatToBring",
                table: "TouristsTours",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<string>(
                name: "MeetingPointMapUrl",
                table: "TouristsTours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KnowBeforeYouGo",
                table: "TouristsTours",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<string>(
                name: "Includes",
                table: "TouristsTours",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 22, 33, 52, 878, DateTimeKind.Utc).AddTicks(4505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 31, 22, 29, 1, 190, DateTimeKind.Utc).AddTicks(8880));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WhatToBring",
                table: "TouristsTours",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeetingPointMapUrl",
                table: "TouristsTours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KnowBeforeYouGo",
                table: "TouristsTours",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Includes",
                table: "TouristsTours",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 22, 29, 1, 190, DateTimeKind.Utc).AddTicks(8880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 31, 22, 33, 52, 878, DateTimeKind.Utc).AddTicks(4505));
        }
    }
}
