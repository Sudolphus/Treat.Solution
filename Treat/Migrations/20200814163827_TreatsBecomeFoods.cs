using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Treat.Migrations
{
    public partial class TreatsBecomeFoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlavorTreat");

            migrationBuilder.DropTable(
                name: "Treats");

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "FlavorFood",
                columns: table => new
                {
                    FlavorFoodId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FlavorId = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlavorFood", x => x.FlavorFoodId);
                    table.ForeignKey(
                        name: "FK_FlavorFood_Flavors_FlavorId",
                        column: x => x.FlavorId,
                        principalTable: "Flavors",
                        principalColumn: "FlavorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlavorFood_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlavorFood_FlavorId",
                table: "FlavorFood",
                column: "FlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_FlavorFood_FoodId",
                table: "FlavorFood",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlavorFood");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.CreateTable(
                name: "Treats",
                columns: table => new
                {
                    TreatId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treats", x => x.TreatId);
                });

            migrationBuilder.CreateTable(
                name: "FlavorTreat",
                columns: table => new
                {
                    FlavorTreatId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FlavorId = table.Column<int>(nullable: false),
                    TreatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlavorTreat", x => x.FlavorTreatId);
                    table.ForeignKey(
                        name: "FK_FlavorTreat_Flavors_FlavorId",
                        column: x => x.FlavorId,
                        principalTable: "Flavors",
                        principalColumn: "FlavorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlavorTreat_Treats_TreatId",
                        column: x => x.TreatId,
                        principalTable: "Treats",
                        principalColumn: "TreatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlavorTreat_FlavorId",
                table: "FlavorTreat",
                column: "FlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_FlavorTreat_TreatId",
                table: "FlavorTreat",
                column: "TreatId");
        }
    }
}
