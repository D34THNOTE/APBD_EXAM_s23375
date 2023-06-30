using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exam.Migrations
{
    /// <inheritdoc />
    public partial class InserExampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "IdArtist", "Nickname" },
                values: new object[,]
                {
                    { 1, "art1" },
                    { 2, "art2" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 30, 18, 9, 42, 1, DateTimeKind.Local).AddTicks(5401), "Test event 1", new DateTime(2023, 6, 30, 10, 9, 42, 1, DateTimeKind.Local).AddTicks(5331) },
                    { 2, new DateTime(2023, 7, 1, 18, 9, 42, 1, DateTimeKind.Local).AddTicks(5413), "Test event 2", new DateTime(2023, 7, 1, 10, 9, 42, 1, DateTimeKind.Local).AddTicks(5409) }
                });

            migrationBuilder.InsertData(
                table: "Organisers",
                columns: new[] { "IdOrganiser", "Name" },
                values: new object[,]
                {
                    { 1, "Organizer 1" },
                    { 2, "Organizer 2" }
                });

            migrationBuilder.InsertData(
                table: "ArtistEvents",
                columns: new[] { "IdArtist", "IdEvent", "PerformanceDate" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2023, 6, 30, 15, 9, 42, 2, DateTimeKind.Local).AddTicks(9486) },
                    { 2, 2, new DateTime(2023, 7, 1, 15, 9, 42, 2, DateTimeKind.Local).AddTicks(9548) }
                });

            migrationBuilder.InsertData(
                table: "EventsOrganisers",
                columns: new[] { "IdEvent", "IdOrganiser" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "IdArtist", "IdEvent" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "IdArtist", "IdEvent" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventsOrganisers",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EventsOrganisers",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organisers",
                keyColumn: "IdOrganiser",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organisers",
                keyColumn: "IdOrganiser",
                keyValue: 2);
        }
    }
}
