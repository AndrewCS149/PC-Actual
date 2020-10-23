using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations.StoreDb
{
    public partial class newImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "~/Images/I9.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://ecom17.blob.core.windows.net/pictures/i9.jpg");
        }
    }
}
