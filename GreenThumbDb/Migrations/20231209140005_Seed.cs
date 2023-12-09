using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbDb.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Instruction", "plantId" },
                values: new object[,]
                {
                    { 11, "Place in indirect sunlight and water thoroughly, allowing the soil to dry between waterings for optimal growth.", 1 },
                    { 12, "Create a humid environment and provide filtered sunlight to promote healthy, vibrant foliage for this tropical beauty.", 2 },
                    { 13, "Water moderately and place in a location with bright, indirect light for stunning and long-lasting blooms.", 3 },
                    { 14, "Plant in nutrient-rich soil and water consistently to encourage the growth of flavorful and aromatic herbs.", 4 },
                    { 15, "Provide well-draining soil and ample sunlight, and water sparingly to maintain the distinctive shape of this succulent.", 5 },
                    { 16, "Place in a sunny location and water regularly, allowing the soil to dry slightly between waterings for optimal health.", 6 },
                    { 17, "Create a trellis for support, plant in full sun, and water consistently to cultivate a thriving and productive vine.", 7 },
                    { 18, "Ensure well-draining soil and provide bright, indirect light for this delicate fern to flourish in a controlled environment.", 8 },
                    { 19, "Water moderately and place in a location with filtered sunlight to encourage the growth of lush and colorful leaves.", 9 },
                    { 20, "Plant in a spacious container with rich soil, water consistently, and provide ample sunlight for robust and healthy growth.", 10 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "WurYLWDQvNzuUtvXe+jTEg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "WtoQ5Wt0fYftPT0IJdYirA==");
        }
    }
}
