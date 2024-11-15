using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment4.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DueDate",
                table: "BookManagers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Penalty",
                table: "BookManagers",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "BookManagers");

            migrationBuilder.DropColumn(
                name: "Penalty",
                table: "BookManagers");
        }
    }
}
