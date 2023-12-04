using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbDb.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { 1, "WurYLWDQvNzuUtvXe+jTEg==", "david" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 10);
        }
    }
}
