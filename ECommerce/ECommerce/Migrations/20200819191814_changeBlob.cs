using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class changeBlob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://ecom17.blob.core.windows.net/pictures/i9.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://ecom17.blob.core.windows.net/pictures/Ryzen5.jpg", "Ryzen 5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://ecom17.blob.core.windows.net/pictures/Ryzen7.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://ecom17.blob.core.windows.net/pictures/CPU.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://ecom17.blob.core.windows.net/pictures/i7.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://ecom17.blob.core.windows.net/pictures/GTX1080.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://ecom17.blob.core.windows.net/pictures/Radeon8940.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://ecom17.blob.core.windows.net/pictures/GigabyteGPU.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "https://ecom17.blob.core.windows.net/pictures/RTX2080.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Image", "Name", "Price" },
                values: new object[] { "https://ecom17.blob.core.windows.net/pictures/gpu.jpg", "ASUS 1060", 300.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://ecommerce17.blob.core.windows.net/pictures/CPU.jpg", "Ryzen 9" });

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
                column: "Image",
                value: "https://ecommerce17.blob.core.windows.net/pictures/RTX2080.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Image", "Name", "Price" },
                values: new object[] { "https://ecommerce17.blob.core.windows.net/pictures/Gigabyte.jpg", "Gigabyte RTX 2060", 650.00m });
        }
    }
}
