using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkodoAPI.Migrations
{
    /// <inheritdoc />
    public partial class usertype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subtype",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtype",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "User");
        }
    }
}
