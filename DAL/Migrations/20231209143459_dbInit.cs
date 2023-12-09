using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class dbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BusStops",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStops", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    cardState = table.Column<int>(type: "int", nullable: false),
                    suitableFrom = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    suitableTo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Busses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    isAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tripId = table.Column<int>(name: "trip_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Busses_Trips_trip_Id",
                        column: x => x.tripId,
                        principalTable: "Trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BusStopTrip",
                columns: table => new
                {
                    BusStopsid = table.Column<int>(type: "int", nullable: false),
                    Tripsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStopTrip", x => new { x.BusStopsid, x.Tripsid });
                    table.ForeignKey(
                        name: "FK_BusStopTrip_BusStops_BusStopsid",
                        column: x => x.BusStopsid,
                        principalTable: "BusStops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusStopTrip_Trips_Tripsid",
                        column: x => x.Tripsid,
                        principalTable: "Trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    departureTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    arrivalTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tripId = table.Column<int>(name: "trip_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_Schedules_Trips_trip_Id",
                        column: x => x.tripId,
                        principalTable: "Trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    isAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    cardId = table.Column<int>(name: "card_Id", type: "int", nullable: false),
                    busId = table.Column<int>(name: "bus_Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Drivers_Busses_bus_Id",
                        column: x => x.busId,
                        principalTable: "Busses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Drivers_Cards_card_Id",
                        column: x => x.cardId,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Passangers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    isInBus = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    cardId = table.Column<int>(name: "card_Id", type: "int", nullable: false),
                    busId = table.Column<int>(name: "bus_Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passangers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Passangers_Busses_bus_Id",
                        column: x => x.busId,
                        principalTable: "Busses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Passangers_Cards_card_Id",
                        column: x => x.cardId,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Busses_trip_Id",
                table: "Busses",
                column: "trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BusStopTrip_Tripsid",
                table: "BusStopTrip",
                column: "Tripsid");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_bus_Id",
                table: "Drivers",
                column: "bus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_card_Id",
                table: "Drivers",
                column: "card_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Passangers_bus_Id",
                table: "Passangers",
                column: "bus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Passangers_card_Id",
                table: "Passangers",
                column: "card_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_trip_Id",
                table: "Schedules",
                column: "trip_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusStopTrip");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Passangers");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "BusStops");

            migrationBuilder.DropTable(
                name: "Busses");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
