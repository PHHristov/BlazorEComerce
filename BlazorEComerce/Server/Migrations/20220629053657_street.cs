using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEComerce.Server.Migrations
{
    public partial class street : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");
        }
    }
}
