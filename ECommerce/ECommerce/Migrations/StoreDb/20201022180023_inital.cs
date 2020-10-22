using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ECommerce.Migrations.StoreDb
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEmail = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Stock = table.Column<string>(nullable: true),
                    Recommendation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CartId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CardType = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price", "Recommendation", "Stock" },
                values: new object[,]
                {
                    { 1, "This product came out in 2017 and features anywhere from 6-18 cores.", "https://ecom17.blob.core.windows.net/pictures/i9.jpg", "Intel core i9", 430.00m, "Use for desktop computers (heat issue with laptops).", "38" },
                    { 2, "This product is a high end computer that specializes in heat management.", "https://ecom17.blob.core.windows.net/pictures/Ryzen5.jpg", "AMD Ryzen 5", 650.00m, "Use this with two 1080p monitors for optimal performance.", "15" },
                    { 3, "Last gen PC that still has fairly good processing power with decent heat management.", "https://ecom17.blob.core.windows.net/pictures/Ryzen7.jpg", "AMD Ryzen 7", 330.00m, "While not as powerful as the Ryzen 9, it is still a solid investment for a personal computer.", "21" },
                    { 4, "Decent product that has 2-8 cores.", "https://ecom17.blob.core.windows.net/pictures/CPU.jpg", "Intel core i5", 200.00m, "If one is on a budget and can't afford the I9, this is a good bet.", "40" },
                    { 5, "The middle road processor between i5 and i9, with 6-12 cores.", "https://ecom17.blob.core.windows.net/pictures/i7.jpg", "Intel core i7", 320.00m, "Only a few left, so buy it while you have the chance!", "5" },
                    { 6, "High end graphics card that is fit for use in the newest generation pc's.", "https://ecom17.blob.core.windows.net/pictures/GTX1080.jpg", "Nvidia GTX 1080", 240.00m, "Expensive, but a great asset for any high end gaming computer.", "9" },
                    { 7, "Radeon's answer to the Nvidia 1080, it is another high end graphics card.", "https://ecom17.blob.core.windows.net/pictures/Radeon8940.jpg", "AMD Radeon 8940", 198.00m, "Slightly less performance but cheaper than the Nvidia 1080. Buy it if you have a budget.", "16" },
                    { 8, "A high end graphics card that is used best with overclocked computers.", "https://ecom17.blob.core.windows.net/pictures/GigabyteGPU.jpg", "MSI GTX 1660", 249.00m, "If you want to maximize performance and don't mind system bugs, this is the product for you!", "3" },
                    { 9, "A last generation Nvidia graphics card, it still possessess solid performance stats.", "https://ecom17.blob.core.windows.net/pictures/RTX2080.jpg", "Nvidia RTX 2080", 250.00m, "Buy if you don't mind not playing on ultra graphics settings.", "11" },
                    { 10, "The best bargain graphics card in the store!", "https://ecom17.blob.core.windows.net/pictures/gpu.jpg", "ASUS GTX 1060", 300.00m, "Buy if you plan on spending your money on other computer parts. We recommend buying more RAM to offset card shortcomings.", "18" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CartId",
                table: "Order",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
