using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristTourGuide.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrationRestirct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_TouristsTours_TouristTourId",
                table: "Vote");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 1, 1, 26, 4, 347, DateTimeKind.Utc).AddTicks(3846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 1, 1, 23, 16, 351, DateTimeKind.Utc).AddTicks(7837));

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_TouristsTours_TouristTourId",
                table: "Vote",
                column: "TouristTourId",
                principalTable: "TouristsTours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_TouristsTours_TouristTourId",
                table: "Vote");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 1, 1, 23, 16, 351, DateTimeKind.Utc).AddTicks(7837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 1, 1, 26, 4, 347, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_TouristsTours_TouristTourId",
                table: "Vote",
                column: "TouristTourId",
                principalTable: "TouristsTours",
                principalColumn: "Id");
        }
    }
}
