using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MFR = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Calories = table.Column<string>(nullable: true),
                    Protein = table.Column<string>(nullable: true),
                    Fat = table.Column<string>(nullable: true),
                    Sodium = table.Column<string>(nullable: true),
                    Carbo = table.Column<string>(nullable: true),
                    Sugars = table.Column<string>(nullable: true),
                    Potassium = table.Column<string>(nullable: true),
                    Vitamins = table.Column<string>(nullable: true),
                    Shelf = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Cups = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
