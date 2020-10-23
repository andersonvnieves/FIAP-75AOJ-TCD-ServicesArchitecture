using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentService.Migrations
{
    public partial class IncidentServicePersistenceIncidentDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncidentStatuses",
                columns: table => new
                {
                    IncidentStatusId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentStatuses", x => x.IncidentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<Guid>(nullable: false),
                    OpenedBy = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ProblemDescription = table.Column<string>(nullable: true),
                    RelatedOrderId = table.Column<Guid>(nullable: false),
                    Resolution = table.Column<string>(nullable: true),
                    IncidentStatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_IncidentStatuses_IncidentStatusId",
                        column: x => x.IncidentStatusId,
                        principalTable: "IncidentStatuses",
                        principalColumn: "IncidentStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentStatusId",
                table: "Incidents",
                column: "IncidentStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "IncidentStatuses");
        }
    }
}
