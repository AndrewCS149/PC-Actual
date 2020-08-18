using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class moreproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Stock",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "This product came out in 2017 and features anywhere from 6-18 cores.", "Use for desktop computers (heat issue with laptops).", "There are currently 38 left in stock" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "This product is a high end computer that specializes in heat management.", "Use this with two 1080p monitors for optimal performance.", "15" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "Last gen PC that still has fairly good processing power with decent heat management.", "While not as powerful as the Ryzen 9, it is still a solid investment for a personal computer.", "21" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "Decent product that has 2-8 cores.", "If one is on a budget and can't afford the I9, this is a good bet.", "40" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "The middle road processor between i5 and i9, with 6-12 cores.", "Only a few left, so buy it while you have the chance!", "5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "High end graphics card that is fit for use in the newest generation pc's.", "Expensive, but a great asset for any high end gaming computer.", "9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "Radeon's answer to the Nvidia 1080, it is another high end graphics card.", "Slightly less performance but cheaper than the Nvidia 1080. Buy it if you have a budget.", "16" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "A high end graphics card that is used best with overclocked computers.", "If you want to maximize performance and don't mind system bugs, this is the product for you!", "3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "A last generation Nvidia graphics card, it still possessess solid performance stats.", "Buy if you don't mind not playing on ultra graphics settings.", "11" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Recommendation", "Stock" },
                values: new object[] { "The best bargain graphics card in the store!", "Buy if you plan on spending your money on other computer parts. We recommend buying more RAM to offset card shortcomings.", "18" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");
        }
    }
}
