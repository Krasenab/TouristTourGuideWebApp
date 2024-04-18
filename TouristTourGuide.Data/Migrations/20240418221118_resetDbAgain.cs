using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TouristTourGuide.Data.Migrations
{
    /// <inheritdoc />
    public partial class resetDbAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristTourReserveDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Village = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuideUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LegalFirmName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ValueAddedTaxIdentificationNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CompanyRegistrationNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegisteredAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AboutTheActivityProvider = table.Column<string>(type: "nvarchar(max)", maxLength: 4500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuideUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristsTours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duaration = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    startEndHouers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerPerson = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Highlights = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotSuitableFor = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MeetingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingPointMapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Includes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WhatToBring = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    KnowBeforeYouGo = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 18, 22, 11, 18, 255, DateTimeKind.Utc).AddTicks(4081)),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    GuideUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristsTours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristsTours_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TouristsTours_GuideUsers_GuideUserId",
                        column: x => x.GuideUserId,
                        principalTable: "GuideUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TouristsTours_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TouristTourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppImages_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppImages_TouristsTours_TouristTourId",
                        column: x => x.TouristTourId,
                        principalTable: "TouristsTours",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    TouristTourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_TouristsTours_TouristTourId",
                        column: x => x.TouristTourId,
                        principalTable: "TouristsTours",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TouristTourBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookQueryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountOfPeople = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAccepted = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TouristTourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristTourBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristTourBookings_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TouristTourBookings_TouristsTours_TouristTourId",
                        column: x => x.TouristTourId,
                        principalTable: "TouristsTours",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TouristTourDates",
                columns: table => new
                {
                    TouristTourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristTourDates", x => new { x.TouristTourId, x.DatesId });
                    table.ForeignKey(
                        name: "FK_TouristTourDates_Dates_DatesId",
                        column: x => x.DatesId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TouristTourDates_TouristsTours_TouristTourId",
                        column: x => x.TouristTourId,
                        principalTable: "TouristsTours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteValue = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TouristTourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_TouristsTours_TouristTourId",
                        column: x => x.TouristTourId,
                        principalTable: "TouristsTours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Culture" },
                    { 2, "Sports" },
                    { 3, "Nature" },
                    { 4, "Food" },
                    { 5, "Audio guides tours" },
                    { 6, "Attractions" },
                    { 7, "City Tours" },
                    { 8, "Safari" },
                    { 9, "Religius and spiritual acttivities" },
                    { 11, "History and culture" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country", "Village" },
                values: new object[,]
                {
                    { 1, null, "Afghanistan", null },
                    { 2, null, "Åland Islands", null },
                    { 3, null, "Albania", null },
                    { 4, null, "Algeria", null },
                    { 5, null, "American Samoa", null },
                    { 6, null, "AndorrA", null },
                    { 7, null, "Angola", null },
                    { 8, null, "Anguilla", null },
                    { 9, null, "Antarctica", null },
                    { 10, null, "Antigua and Barbuda", null },
                    { 11, null, "Argentina", null },
                    { 12, null, "Armenia", null },
                    { 13, null, "Aruba", null },
                    { 14, null, "Australia", null },
                    { 15, null, "Austria", null },
                    { 16, null, "Azerbaijan", null },
                    { 17, null, "Bahamas", null },
                    { 18, null, "Bahrain", null },
                    { 19, null, "Bangladesh", null },
                    { 20, null, "Barbados", null },
                    { 21, null, "Belarus", null },
                    { 22, null, "Belgium", null },
                    { 23, null, "Belize", null },
                    { 24, null, "Benin", null },
                    { 25, null, "Bermuda", null },
                    { 26, null, "Bhutan", null },
                    { 27, null, "Bolivia", null },
                    { 28, null, "Bosnia and Herzegovina", null },
                    { 29, null, "Botswana", null },
                    { 30, null, "Bouvet Island", null },
                    { 31, null, "Brazil", null },
                    { 32, null, "British Indian Ocean Territory", null },
                    { 33, null, "Brunei Darussalam", null },
                    { 34, null, "Bulgaria", null },
                    { 35, null, "Burkina Faso", null },
                    { 36, null, "Burundi", null },
                    { 37, null, "Cambodia", null },
                    { 38, null, "Cameroon", null },
                    { 39, null, "Canada", null },
                    { 40, null, "Cape Verde", null },
                    { 41, null, "Cayman Islands", null },
                    { 42, null, "Central African Republic", null },
                    { 43, null, "Chad", null },
                    { 44, null, "Chile", null },
                    { 45, null, "China", null },
                    { 46, null, "Christmas Island", null },
                    { 47, null, "Cocos (Keeling) Islands", null },
                    { 48, null, "Colombia", null },
                    { 49, null, "Comoros", null },
                    { 50, null, "Congo", null },
                    { 51, null, "Congo, The Democratic Republic of the", null },
                    { 52, null, "Cook Islands", null },
                    { 53, null, "Costa Rica", null },
                    { 54, null, "Cote D\"Ivoire", null },
                    { 55, null, "Croatia", null },
                    { 56, null, "Cuba", null },
                    { 57, null, "Cyprus", null },
                    { 58, null, "Czech Republic", null },
                    { 59, null, "Denmark", null },
                    { 60, null, "Djibouti", null },
                    { 61, null, "Dominica", null },
                    { 62, null, "Dominican Republic", null },
                    { 63, null, "Ecuador", null },
                    { 64, null, "Egypt", null },
                    { 65, null, "El Salvador", null },
                    { 66, null, "Equatorial Guinea", null },
                    { 67, null, "Eritrea", null },
                    { 68, null, "Estonia", null },
                    { 69, null, "Ethiopia", null },
                    { 70, null, "Falkland Islands (Malvinas)", null },
                    { 71, null, "Faroe Islands", null },
                    { 72, null, "Fiji", null },
                    { 73, null, "Finland", null },
                    { 74, null, "France", null },
                    { 75, null, "French Guiana", null },
                    { 76, null, "French Polynesia", null },
                    { 77, null, "French Southern Territories", null },
                    { 78, null, "Gabon", null },
                    { 79, null, "Gambia", null },
                    { 80, null, "Georgia", null },
                    { 81, null, "Germany", null },
                    { 82, null, "Ghana", null },
                    { 83, null, "Gibraltar", null },
                    { 84, null, "Greece", null },
                    { 85, null, "Greenland", null },
                    { 86, null, "Grenada", null },
                    { 87, null, "Guadeloupe", null },
                    { 88, null, "Guam", null },
                    { 89, null, "Guatemala", null },
                    { 90, null, "Guernsey", null },
                    { 91, null, "Guinea", null },
                    { 92, null, "Guinea-Bissau", null },
                    { 93, null, "Guyana", null },
                    { 94, null, "Haiti", null },
                    { 95, null, "Heard Island and Mcdonald Islands", null },
                    { 96, null, "Holy See (Vatican City State)", null },
                    { 97, null, "Honduras", null },
                    { 98, null, "Hong Kong", null },
                    { 99, null, "Hungary", null },
                    { 100, null, "Iceland", null },
                    { 101, null, "India", null },
                    { 102, null, "Indonesia", null },
                    { 103, null, "Iran, Islamic Republic Of", null },
                    { 104, null, "Iraq", null },
                    { 105, null, "Ireland", null },
                    { 106, null, "Isle of Man", null },
                    { 107, null, "Israel", null },
                    { 108, null, "Italy", null },
                    { 109, null, "Jamaica", null },
                    { 110, null, "Japan", null },
                    { 111, null, "Jersey", null },
                    { 112, null, "Jordan", null },
                    { 113, null, "Kazakhstan", null },
                    { 114, null, "Kenya", null },
                    { 115, null, "Kiribati", null },
                    { 116, null, "Korea, Democratic People\"S Republic of", null },
                    { 117, null, "Korea, Republic of", null },
                    { 118, null, "Kuwait", null },
                    { 119, null, "Kyrgyzstan", null },
                    { 120, null, "Lao People\"S Democratic Republic", null },
                    { 121, null, "Latvia", null },
                    { 122, null, "Lebanon", null },
                    { 123, null, "Lesotho", null },
                    { 124, null, "Liberia", null },
                    { 125, null, "Libyan Arab Jamahiriya", null },
                    { 126, null, "Liechtenstein", null },
                    { 127, null, "Lithuania", null },
                    { 128, null, "Luxembourg", null },
                    { 129, null, "Macao", null },
                    { 130, null, "Macedonia, The Former Yugoslav Republic of", null },
                    { 131, null, "Madagascar", null },
                    { 132, null, "Malawi", null },
                    { 133, null, "Malaysia", null },
                    { 134, null, "Maldives", null },
                    { 135, null, "Mali", null },
                    { 136, null, "Malta", null },
                    { 137, null, "Marshall Islands", null },
                    { 138, null, "Martinique", null },
                    { 139, null, "Mauritania", null },
                    { 140, null, "Mauritius", null },
                    { 141, null, "Mayotte", null },
                    { 142, null, "Mexico", null },
                    { 143, null, "Micronesia, Federated States of", null },
                    { 144, null, "Moldova, Republic of", null },
                    { 145, null, "Monaco", null },
                    { 146, null, "Mongolia", null },
                    { 147, null, "Montserrat", null },
                    { 148, null, "Morocco", null },
                    { 149, null, "Mozambique", null },
                    { 150, null, "Myanmar", null },
                    { 151, null, "Namibia", null },
                    { 152, null, "Nauru", null },
                    { 153, null, "Nepal", null },
                    { 154, null, "Netherlands", null },
                    { 155, null, "Netherlands Antilles", null },
                    { 156, null, "New Caledonia", null },
                    { 157, null, "New Zealand", null },
                    { 158, null, "Nicaragua", null },
                    { 159, null, "Niger", null },
                    { 160, null, "Nigeria", null },
                    { 161, null, "Niue", null },
                    { 162, null, "Norfolk Island", null },
                    { 163, null, "Northern Mariana Islands", null },
                    { 164, null, "Norway", null },
                    { 165, null, "Oman", null },
                    { 166, null, "Pakistan", null },
                    { 167, null, "Palau", null },
                    { 168, null, "Palestinian Territory, Occupied", null },
                    { 169, null, "Panama", null },
                    { 170, null, "Papua New Guinea", null },
                    { 171, null, "Paraguay", null },
                    { 172, null, "Peru", null },
                    { 173, null, "Philippines", null },
                    { 174, null, "Pitcairn", null },
                    { 175, null, "Poland", null },
                    { 176, null, "Portugal", null },
                    { 177, null, "Puerto Rico", null },
                    { 178, null, "Qatar", null },
                    { 179, null, "Reunion", null },
                    { 180, null, "Romania", null },
                    { 181, null, "Russian Federation", null },
                    { 182, null, "RWANDA", null },
                    { 183, null, "Saint Helena", null },
                    { 184, null, "Saint Kitts and Nevis", null },
                    { 185, null, "Saint Lucia", null },
                    { 186, null, "Saint Pierre and Miquelon", null },
                    { 187, null, "Saint Vincent and the Grenadines", null },
                    { 188, null, "Samoa", null },
                    { 189, null, "San Marino", null },
                    { 190, null, "Sao Tome and Principe", null },
                    { 191, null, "Saudi Arabia", null },
                    { 192, null, "Senegal", null },
                    { 193, null, "Serbia and Montenegro", null },
                    { 194, null, "Seychelles", null },
                    { 195, null, "Sierra Leone", null },
                    { 196, null, "Singapore", null },
                    { 197, null, "Slovakia", null },
                    { 198, null, "Slovenia", null },
                    { 199, null, "Solomon Islands", null },
                    { 200, null, "Somalia", null },
                    { 201, null, "South Africa", null },
                    { 202, null, "South Georgia and the South Sandwich Islands", null },
                    { 203, null, "Spain", null },
                    { 204, null, "Sri Lanka", null },
                    { 205, null, "Sudan", null },
                    { 206, null, "Suriname", null },
                    { 207, null, "Svalbard and Jan Mayen", null },
                    { 208, null, "Swaziland", null },
                    { 209, null, "Sweden", null },
                    { 210, null, "Switzerland", null },
                    { 211, null, "Syrian Arab Republic", null },
                    { 212, null, "Taiwan, Province of China", null },
                    { 213, null, "Tajikistan", null },
                    { 214, null, "Tanzania, United Republic of", null },
                    { 215, null, "Thailand", null },
                    { 216, null, "Timor-Leste", null },
                    { 217, null, "Togo", null },
                    { 218, null, "Tokelau", null },
                    { 219, null, "Tonga", null },
                    { 220, null, "Trinidad and Tobago", null },
                    { 221, null, "Tunisia", null },
                    { 222, null, "Turkey", null },
                    { 223, null, "Turkmenistan", null },
                    { 224, null, "Turks and Caicos Islands", null },
                    { 225, null, "Tuvalu", null },
                    { 226, null, "Uganda", null },
                    { 227, null, "Ukraine", null },
                    { 228, null, "United Arab Emirates", null },
                    { 229, null, "United Kingdom", null },
                    { 230, null, "United States", null },
                    { 231, null, "United States Minor Outlying Islands", null },
                    { 232, null, "Uruguay", null },
                    { 233, null, "Uzbekistan", null },
                    { 234, null, "Vanuatu", null },
                    { 235, null, "Venezuela", null },
                    { 236, null, "Viet Nam", null },
                    { 237, null, "Virgin Islands, British", null },
                    { 238, null, "Virgin Islands, U.S.", null },
                    { 239, null, "Wallis and Futuna", null },
                    { 240, null, "Western Sahara", null },
                    { 241, null, "Yemen", null },
                    { 242, null, "Zambia", null },
                    { 243, null, "Zimbabwe", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppImages_ApplicationUserId",
                table: "AppImages",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppImages_TouristTourId",
                table: "AppImages",
                column: "TouristTourId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TouristTourId",
                table: "Comments",
                column: "TouristTourId");

            migrationBuilder.CreateIndex(
                name: "IX_GuideUsers_ApplicationUserId",
                table: "GuideUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristsTours_CategoryId",
                table: "TouristsTours",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristsTours_GuideUserId",
                table: "TouristsTours",
                column: "GuideUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristsTours_LocationId",
                table: "TouristsTours",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristTourBookings_ApplicationUserId",
                table: "TouristTourBookings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristTourBookings_TouristTourId",
                table: "TouristTourBookings",
                column: "TouristTourId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristTourDates_DatesId",
                table: "TouristTourDates",
                column: "DatesId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ApplicationUserId",
                table: "Votes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_TouristTourId",
                table: "Votes",
                column: "TouristTourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppImages");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "TouristTourBookings");

            migrationBuilder.DropTable(
                name: "TouristTourDates");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "TouristsTours");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "GuideUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
