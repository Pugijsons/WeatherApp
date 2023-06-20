using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentWeatherModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    temperature = table.Column<double>(type: "float", nullable: false),
                    windspeed = table.Column<double>(type: "float", nullable: false),
                    winddirection = table.Column<double>(type: "float", nullable: false),
                    weathercode = table.Column<int>(type: "int", nullable: false),
                    is_day = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentWeatherModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPCallResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    query = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lat = table.Column<double>(type: "float", nullable: false),
                    lon = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPCallResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    generationtime_ms = table.Column<double>(type: "float", nullable: false),
                    utc_offset_seconds = table.Column<int>(type: "int", nullable: false),
                    timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timezone_abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    elevation = table.Column<double>(type: "float", nullable: false),
                    current_weatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherData_CurrentWeatherModel_current_weatherId",
                        column: x => x.current_weatherId,
                        principalTable: "CurrentWeatherModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_current_weatherId",
                table: "WeatherData",
                column: "current_weatherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPCallResponse");

            migrationBuilder.DropTable(
                name: "WeatherData");

            migrationBuilder.DropTable(
                name: "CurrentWeatherModel");
        }
    }
}
