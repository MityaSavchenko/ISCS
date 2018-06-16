using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISCS.Data.Migrations
{
    public partial class Configure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HazardControls_Hazards_HazardId",
                table: "HazardControls");

            migrationBuilder.AlterColumn<long>(
                name: "HazardId",
                table: "HazardControls",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HazardControls_Hazards_HazardId",
                table: "HazardControls",
                column: "HazardId",
                principalTable: "Hazards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HazardControls_Hazards_HazardId",
                table: "HazardControls");

            migrationBuilder.AlterColumn<long>(
                name: "HazardId",
                table: "HazardControls",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_HazardControls_Hazards_HazardId",
                table: "HazardControls",
                column: "HazardId",
                principalTable: "Hazards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
