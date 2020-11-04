using Microsoft.EntityFrameworkCore.Migrations;

namespace menuEditor.Data.Migrations
{
    public partial class fixMenuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "menuItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "menuItems");
        }
    }
}
