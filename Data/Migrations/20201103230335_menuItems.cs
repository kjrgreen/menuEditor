using Microsoft.EntityFrameworkCore.Migrations;

namespace menuEditor.Data.Migrations
{
    public partial class menuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    MenuItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menuItems_menuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "menuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_menuItems_MenuItemId",
                table: "menuItems",
                column: "MenuItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menuItems");
        }
    }
}
