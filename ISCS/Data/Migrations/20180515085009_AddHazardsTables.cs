using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISCS.Data.Migrations
{
    public partial class AddHazardsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TechCardState",
                table: "TechCards",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Hazards",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HazardLevel = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hazards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HazardControls",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HazardId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HazardControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HazardControls_Hazards_HazardId",
                        column: x => x.HazardId,
                        principalTable: "Hazards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechCardHazardControls",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HazardControlId = table.Column<long>(nullable: false),
                    TechCardId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechCardHazardControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechCardHazardControls_HazardControls_HazardControlId",
                        column: x => x.HazardControlId,
                        principalTable: "HazardControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechCardHazardControls_TechCards_TechCardId",
                        column: x => x.TechCardId,
                        principalTable: "TechCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HazardControls_HazardId",
                table: "HazardControls",
                column: "HazardId");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardHazardControls_HazardControlId",
                table: "TechCardHazardControls",
                column: "HazardControlId");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardHazardControls_TechCardId",
                table: "TechCardHazardControls",
                column: "TechCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechCardHazardControls");

            migrationBuilder.DropTable(
                name: "HazardControls");

            migrationBuilder.DropTable(
                name: "Hazards");

            migrationBuilder.AlterColumn<int>(
                name: "TechCardState",
                table: "TechCards",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
