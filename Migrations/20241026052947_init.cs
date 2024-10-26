using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkodoAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuperId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Admin_SuperId",
                        column: x => x.SuperId,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    AddressDetails = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    LogType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLog_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsappPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    AddressDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ApartmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFurnished = table.Column<bool>(type: "bit", nullable: false),
                    OccupierCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    RateIncludes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministrativeFees = table.Column<int>(type: "int", nullable: false),
                    Insurance = table.Column<int>(type: "int", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    isAccepted = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ad_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocument_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFeedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFeedback_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTransaction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdBedroom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdId = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdBedroom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdBedroom_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdImage",
                columns: table => new
                {
                    ImageUrl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdImage", x => x.ImageUrl);
                    table.ForeignKey(
                        name: "FK_AdImage_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdReport",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdReport", x => new { x.SessionId, x.AdId });
                    table.ForeignKey(
                        name: "FK_AdReport_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdUserView",
                columns: table => new
                {
                    AdId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdUserView", x => new { x.AdId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AdUserView_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdUserView_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdUserWishlist",
                columns: table => new
                {
                    AdId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdUserWishlist", x => new { x.AdId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AdUserWishlist_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdUserWishlist_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdBedroomUserOccupancy",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdBedroomId = table.Column<int>(type: "int", nullable: false),
                    OccupiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OccupancyInterval = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdBedroomUserOccupancy", x => new { x.UserId, x.AdBedroomId });
                    table.ForeignKey(
                        name: "FK_AdBedroomUserOccupancy_AdBedroom_AdBedroomId",
                        column: x => x.AdBedroomId,
                        principalTable: "AdBedroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdBedroomUserOccupancy_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ad_UserId",
                table: "Ad",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdBedroom_AdId",
                table: "AdBedroom",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdBedroomUserOccupancy_AdBedroomId",
                table: "AdBedroomUserOccupancy",
                column: "AdBedroomId");

            migrationBuilder.CreateIndex(
                name: "IX_AdImage_AdId",
                table: "AdImage",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_SuperId",
                table: "Admin",
                column: "SuperId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLog_AdminId",
                table: "AdminLog",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdReport_AdId",
                table: "AdReport",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdUserView_UserId",
                table: "AdUserView",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdUserWishlist_UserId",
                table: "AdUserWishlist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UniversityId",
                table: "User",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_UserId",
                table: "UserDocument",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedback_UserId",
                table: "UserFeedback",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTransaction_UserId",
                table: "UserTransaction",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdBedroomUserOccupancy");

            migrationBuilder.DropTable(
                name: "AdImage");

            migrationBuilder.DropTable(
                name: "AdminLog");

            migrationBuilder.DropTable(
                name: "AdReport");

            migrationBuilder.DropTable(
                name: "AdUserView");

            migrationBuilder.DropTable(
                name: "AdUserWishlist");

            migrationBuilder.DropTable(
                name: "UserDocument");

            migrationBuilder.DropTable(
                name: "UserFeedback");

            migrationBuilder.DropTable(
                name: "UserTransaction");

            migrationBuilder.DropTable(
                name: "AdBedroom");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
