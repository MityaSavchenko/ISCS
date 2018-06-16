using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISCS.Data.Migrations
{
    public partial class RemoveUselessColumnAndAddOperationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechCardOperationsState",
                table: "TechCards");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TechCards",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 15, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Operations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Operations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TechCards",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "TechCardOperationsState",
                table: "TechCards",
                nullable: false,
                defaultValue: 0);
        }
    }
}
