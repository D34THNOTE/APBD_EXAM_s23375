using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Migrations
{
    /// <inheritdoc />
    public partial class ArtistEventAndAssociationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    IdArtist = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.IdArtist);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "ArtistEvents",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false),
                    IdArtist = table.Column<int>(type: "int", nullable: false),
                    PerformanceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Artist_Event_pk", x => new { x.IdArtist, x.IdEvent });
                    table.ForeignKey(
                        name: "FK_ArtistEvents_Artists_IdArtist",
                        column: x => x.IdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistEvents_Events_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistEvents_IdEvent",
                table: "ArtistEvents",
                column: "IdEvent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistEvents");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
