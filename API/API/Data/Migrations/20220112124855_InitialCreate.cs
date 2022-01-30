using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });
/*
            migrationBuilder.CreateTable(
                name: "CSNIV_Senha",
                columns: table => new
                {
                    NumCotista = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Senha = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    DataAlt = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSNIV_Senha", x => x.NumCotista);
                });
*/                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUser");
/*
            migrationBuilder.DropTable(
                name: "CSNIV_Senha");
*/
        }
    }
}
