using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristTourGuide.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 21, 10, 49, 528, DateTimeKind.Utc).AddTicks(8931),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 20, 54, 22, 983, DateTimeKind.Utc).AddTicks(1727));

            migrationBuilder.InsertData(
                table: "TouristsTours",
                columns: new[] { "Id", "CategoryId", "Duaration", "FullDescription", "GuideUserId", "Highlights", "Includes", "KnowBeforeYouGo", "LocationId", "MeetingPoint", "MeetingPointMapUrl", "NotSuitableFor", "PricePerPerson", "TourName", "WhatToBring", "startEndHouers" },
                values: new object[] { new Guid("f4e0c782-d1a4-42d1-9182-90b6fb2935e4"), 1, "2.5 hours", "Experience the London of The Beatles with Richard Porter, author of the book Guide to the Beatles London.Discover the locations and landmarks where The Fab Four recorded, lived, and socialized in London during the Swinging Sixties.", new Guid("9a4399f1-422b-4911-bccb-f3f01004235a"), "Discover where The Beatles recorded, lived, and socialized in 1960s London and many others", null, null, 1, "Meet Richard outside Exit 1 of Tottenham Court Road Station. He will be holding 'Beatles Walks' leaflets and wearing a Beatles shirt or hat.", null, null, 45.75m, "Beatles Tour incl. Abbey Road with Richard Porter", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristsTours",
                keyColumn: "Id",
                keyValue: new Guid("f4e0c782-d1a4-42d1-9182-90b6fb2935e4"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TouristsTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 20, 54, 22, 983, DateTimeKind.Utc).AddTicks(1727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 21, 10, 49, 528, DateTimeKind.Utc).AddTicks(8931));
        }
    }
}
