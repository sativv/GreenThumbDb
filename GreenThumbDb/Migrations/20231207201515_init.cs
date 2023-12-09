using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbDb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instructionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    InstructionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.InstructionId);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_plantId",
                        column: x => x.plantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    GardenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.GardenId);
                    table.ForeignKey(
                        name: "FK_Gardens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenPlants",
                columns: table => new
                {
                    GardenId = table.Column<int>(type: "int", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenPlants", x => new { x.PlantId, x.GardenId });
                    table.ForeignKey(
                        name: "FK_GardenPlants_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "GardenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenPlants_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Name", "instructionId" },
                values: new object[,]
                {
                    { 1, "Sunshine Succulent", 1 },
                    { 2, "Mystic Moonflower", 2 },
                    { 3, "Zen Zephyr Orchid", 3 },
                    { 4, "Crimson Cascade Fern", 4 },
                    { 5, "Azure Breeze Bluebell", 5 },
                    { 6, "Silver Serenity Sage", 6 },
                    { 7, "Velvet Violet Verbena", 7 },
                    { 8, "Emerald Echo Eucalyptus", 8 },
                    { 9, "Golden Glow Gazania", 9 },
                    { 10, "Rustic Rosemary Radiance", 10 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[] { 1, "WtoQ5Wt0fYftPT0IJdYirA==", "david" });

            migrationBuilder.InsertData(
                table: "Gardens",
                columns: new[] { "GardenId", "Name", "UserId" },
                values: new object[] { 1, "garden of david", 1 });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Instruction", "plantId" },
                values: new object[,]
                {
                    { 1, "Place in a sunny spot and water sparingly to keep this desert beauty thriving", 1 },
                    { 2, "Plant in well-draining soil and water in the evening for enchanting blooms under the moonlight.", 2 },
                    { 3, "Provide high humidity and a peaceful environment for this orchid to flourish; avoid direct sunlight.", 3 },
                    { 4, "Keep the soil consistently moist and mist the fern regularly to maintain its lush, cascading fronds.", 4 },
                    { 5, "Plant in a cool, shaded area and water regularly for a burst of blue blooms in the spring.", 5 },
                    { 6, "Trim regularly for bushier growth and plant in well-draining soil to prevent waterlogging.", 6 },
                    { 7, " Allow the soil to dry between watering, and place in a sunny location to enjoy the vibrant violet blossoms.", 7 },
                    { 8, "Provide ample sunlight and well-draining soil; prune occasionally for a bushier appearance and enhanced aroma.", 8 },
                    { 9, "Plant in a sunny spot with good drainage and water sparingly to enjoy the radiant golden blooms.", 9 },
                    { 10, "Thrives in well-draining soil and prefers drier conditions; trim regularly for a fragrant and compact rosemary bush.", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlants_GardenId",
                table: "GardenPlants",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_plantId",
                table: "Instructions",
                column: "plantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenPlants");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
