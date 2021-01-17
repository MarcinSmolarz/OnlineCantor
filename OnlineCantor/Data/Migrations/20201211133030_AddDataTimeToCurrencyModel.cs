using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCantor.Data.Migrations
{
    public partial class AddDataTimeToCurrencyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataTime",
                table: "Currency",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataTime",
                table: "Currency");
        }
    }
}
