using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class allphotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/i9.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/CPU.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/Ryzen7.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/CPU-3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/i7.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/GTX1080.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/Radeon.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/GPU.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://ecommerce17.blob.core.windows.net/pictures/RTX2080.jpg", "RTX 2080" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://ecommerce17.blob.core.windows.net/pictures/Gigabyte.jpg", "Gigabyte RTX 2060" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg", "Dell ATI" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://ecommerce17.blob.core.windows.net/pictures/PC.jpg", "Nvidia Quadro GT-100" });
        }
    }
}
