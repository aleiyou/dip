using Microsoft.EntityFrameworkCore.Migrations;

namespace dip.web.Migrations
{
    public partial class AddIndexOverride : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Dips_Plaque",
                table: "Dips",
                column: "Plaque",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dips_Plaque",
                table: "Dips");
        }
    }
}
