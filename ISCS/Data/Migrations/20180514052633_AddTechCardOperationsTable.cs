using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISCS.Data.Migrations
{
    public partial class AddTechCardOperationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentOperations",
                table: "EquipmentOperations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TechCards",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "TechCardOperationsState",
                table: "TechCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechCardState",
                table: "TechCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "EquipmentOperations",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentOperations",
                table: "EquipmentOperations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TechCardOperations",
                columns: table => new
                {
                    TechCardId = table.Column<long>(nullable: false),
                    EquipmentOperationId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechCardOperations", x => new { x.TechCardId, x.EquipmentOperationId });
                    table.ForeignKey(
                        name: "FK_TechCardOperations_EquipmentOperations_EquipmentOperationId",
                        column: x => x.EquipmentOperationId,
                        principalTable: "EquipmentOperations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechCardOperations_TechCards_TechCardId",
                        column: x => x.TechCardId,
                        principalTable: "TechCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentOperations_OperationId",
                table: "EquipmentOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardOperations_EquipmentOperationId",
                table: "TechCardOperations",
                column: "EquipmentOperationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechCardOperations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentOperations",
                table: "EquipmentOperations");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentOperations_OperationId",
                table: "EquipmentOperations");

            migrationBuilder.DropColumn(
                name: "TechCardOperationsState",
                table: "TechCards");

            migrationBuilder.DropColumn(
                name: "TechCardState",
                table: "TechCards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EquipmentOperations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TechCards",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 13, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentOperations",
                table: "EquipmentOperations",
                columns: new[] { "OperationId", "EquipmentId" });
        }
    }
}
