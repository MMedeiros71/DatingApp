using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ExtendedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AppUser",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AppUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AppUser",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AppUser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AppUser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AppUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "AppUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "AppUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnownAs",
                table: "AppUser",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "AppUser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "AppUser",
                nullable: true);
                
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    AppUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "KnownAs",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "AppUser");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AppUser",
                newName: "UserName");
        }
    }
}
