using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Airlines.Infrastructure.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirplaneFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureAirportCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAirportCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ArrivalDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DepartureTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    AirplaneModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfPassport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandLuggageAvailability = table.Column<bool>(type: "bit", nullable: false),
                    TotalBaggageWeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirplaneModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyId = table.Column<int>(type: "int", nullable: false),
                    RangeOfFlight = table.Column<double>(type: "float", nullable: false),
                    PassengerCapacity = table.Column<int>(type: "int", nullable: false),
                    CargoCapacity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirplaneModels_AirplaneFamilies_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "AirplaneFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AirplaneFamilies",
                columns: new[] { "Id", "Manufacturer", "Name" },
                values: new object[,]
                {
                    { 1, "Airbus", "A320" },
                    { 2, "Boeing", "B737" },
                    { 3, "Sukhoi", "SSJ" },
                    { 4, "Irkut", "MC-21" },
                    { 5, "Embraer", "E190" },
                    { 6, "Bombardier", "CRJ" },
                    { 7, "Tupolev", "Tu-204" },
                    { 8, "Ilyushin", "Il-96" },
                    { 9, "Airbus", "A350" },
                    { 10, "Boeing", "B777" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneModelId", "ArrivalDate", "DepartureAirportCode", "DepartureDate", "DepartureTime", "DestinationAirportCode", "Duration", "FlightNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2025, 10, 1), "SVO", new DateOnly(2025, 10, 1), new TimeOnly(8, 30, 0), "LED", new TimeSpan(0, 1, 12, 0, 0), "SU100" },
                    { 2, 2, new DateOnly(2025, 10, 2), "SVO", new DateOnly(2025, 10, 2), new TimeOnly(12, 0, 0), "LED", new TimeSpan(0, 1, 12, 0, 0), "SU101" },
                    { 3, 10, new DateOnly(2025, 11, 1), "CDG", new DateOnly(2025, 11, 1), new TimeOnly(10, 15, 0), "JFK", new TimeSpan(0, 8, 0, 0, 0), "AF200" },
                    { 4, 9, new DateOnly(2025, 12, 1), "FRA", new DateOnly(2025, 12, 1), new TimeOnly(14, 45, 0), "DXB", new TimeSpan(0, 6, 30, 0, 0), "LH300" },
                    { 5, 8, new DateOnly(2025, 12, 5), "SVO", new DateOnly(2025, 12, 5), new TimeOnly(21, 0, 0), "PEK", new TimeSpan(0, 7, 30, 0, 0), "SU400" },
                    { 6, 6, new DateOnly(2025, 9, 20), "LTN", new DateOnly(2025, 9, 20), new TimeOnly(7, 10, 0), "AMS", new TimeSpan(0, 1, 0, 0, 0), "U600" },
                    { 7, 10, new DateOnly(2025, 9, 25), "LHR", new DateOnly(2025, 9, 25), new TimeOnly(16, 0, 0), "JFK", new TimeSpan(0, 8, 0, 0, 0), "BA700" },
                    { 8, 9, new DateOnly(2025, 11, 16), "AMS", new DateOnly(2025, 11, 15), new TimeOnly(18, 30, 0), "NRT", new TimeSpan(0, 11, 0, 0, 0), "KL800" },
                    { 9, 8, new DateOnly(2025, 10, 10), "SVO", new DateOnly(2025, 10, 10), new TimeOnly(13, 20, 0), "JFK", new TimeSpan(0, 9, 0, 0, 0), "SU900" },
                    { 10, 5, new DateOnly(2025, 12, 31), "NRT", new DateOnly(2025, 12, 31), new TimeOnly(9, 0, 0), "HND", new TimeSpan(0, 1, 6, 0, 0), "JL1000" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "BirthDate", "FullName", "NumberOfPassport" },
                values: new object[,]
                {
                    { 1, new DateOnly(2004, 6, 28), "Jessica Parker", "1234567890" },
                    { 2, new DateOnly(1985, 3, 15), "Anna Ivanova", "2345678901" },
                    { 3, new DateOnly(1992, 11, 10), "John Smith", "3456789012" },
                    { 4, new DateOnly(1988, 7, 7), "Maria Gonzalez", "4567890123" },
                    { 5, new DateOnly(1995, 2, 28), "Chen Wei", "5678901234" },
                    { 6, new DateOnly(1993, 9, 14), "Fatima Al-Farsi", "6789012345" },
                    { 7, new DateOnly(1980, 12, 1), "James Brown", "7890123456" },
                    { 8, new DateOnly(1999, 8, 19), "Sophia Lee", "8901234567" },
                    { 9, new DateOnly(1987, 4, 9), "Ahmed Khan", "9012345678" },
                    { 10, new DateOnly(1991, 6, 30), "Emily Davis", "0123456789" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlightId", "HandLuggageAvailability", "PassengerId", "SeatNumber", "TotalBaggageWeight" },
                values: new object[,]
                {
                    { 1, 1, true, 1, "12A", 0.0 },
                    { 2, 1, false, 2, "14C", 20.0 },
                    { 3, 1, true, 3, "22B", 0.0 },
                    { 4, 3, true, 4, "1A", 8.0 },
                    { 5, 5, true, 5, "5D", 25.0 },
                    { 6, 6, false, 6, "18F", 30.0 },
                    { 7, 6, true, 7, "8C", 12.0 },
                    { 8, 8, true, 8, "9B", 18.0 },
                    { 9, 9, true, 9, "2E", 28.0 },
                    { 10, 10, false, 10, "3A", 22.0 }
                });

            migrationBuilder.InsertData(
                table: "AirplaneModels",
                columns: new[] { "Id", "CargoCapacity", "FamilyId", "ModelName", "PassengerCapacity", "RangeOfFlight" },
                values: new object[,]
                {
                    { 1, 20.0, 1, "A320-200", 180, 6100.0 },
                    { 2, 18.0, 2, "737-800", 189, 5436.0 },
                    { 3, 12.0, 3, "SSJ100", 108, 4500.0 },
                    { 4, 22.0, 4, "MC-21-300", 211, 6000.0 },
                    { 5, 10.0, 5, "E190", 100, 4400.0 },
                    { 6, 8.0, 6, "CRJ900", 90, 2800.0 },
                    { 7, 25.0, 7, "Tu-204-300", 230, 9000.0 },
                    { 8, 40.0, 8, "Il-96-300", 262, 11000.0 },
                    { 9, 45.0, 9, "A350-900", 350, 15000.0 },
                    { 10, 50.0, 10, "B777-300ER", 396, 13650.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirplaneModels_FamilyId",
                table: "AirplaneModels",
                column: "FamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirplaneModels");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AirplaneFamilies");
        }
    }
}
