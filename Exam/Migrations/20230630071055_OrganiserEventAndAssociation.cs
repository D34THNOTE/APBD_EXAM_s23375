using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Migrations
{
    /// <inheritdoc />
    public partial class OrganiserEventAndAssociation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisers",
                columns: table => new
                {
                    IdOrganiser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisers", x => x.IdOrganiser);
                });

            migrationBuilder.CreateTable(
                name: "EventsOrganisers",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false),
                    IdOrganiser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Event_Organiser`_pk", x => new { x.IdEvent, x.IdOrganiser });
                    table.ForeignKey(
                        name: "FK_EventsOrganisers_Events_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsOrganisers_Organisers_IdOrganiser",
                        column: x => x.IdOrganiser,
                        principalTable: "Organisers",
                        principalColumn: "IdOrganiser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsOrganisers_IdOrganiser",
                table: "EventsOrganisers",
                column: "IdOrganiser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsOrganisers");

            migrationBuilder.DropTable(
                name: "Organisers");
        }
    }
}
