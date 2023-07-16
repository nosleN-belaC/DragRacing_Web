using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragRacing_Web.Migrations
{
    /// <inheritdoc />
    public partial class firstTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Engine_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Engine_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<bool>(type: "bit", nullable: false),
                    N_A = table.Column<bool>(type: "bit", nullable: false),
                    Fuel_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tune = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Engine_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Track_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Track_ID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Car_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tire_Compound = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Engine_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Car_ID);
                    table.ForeignKey(
                        name: "FK_Cars_Engines_Engine_ID",
                        column: x => x.Engine_ID,
                        principalTable: "Engines",
                        principalColumn: "Engine_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Driver_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hometown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Racing_Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Car_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Driver_ID);
                    table.ForeignKey(
                        name: "FK_Drivers_Cars_Car_ID",
                        column: x => x.Car_ID,
                        principalTable: "Cars",
                        principalColumn: "Car_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Result_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Driver_ID = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weather = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Track_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Result_ID);
                    table.ForeignKey(
                        name: "FK_Results_Drivers_Driver_ID",
                        column: x => x.Driver_ID,
                        principalTable: "Drivers",
                        principalColumn: "Driver_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Tracks_Track_ID",
                        column: x => x.Track_ID,
                        principalTable: "Tracks",
                        principalColumn: "Track_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Engine_ID",
                table: "Cars",
                column: "Engine_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_Car_ID",
                table: "Drivers",
                column: "Car_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Driver_ID",
                table: "Results",
                column: "Driver_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Track_ID",
                table: "Results",
                column: "Track_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Engines");
        }
    }
}
