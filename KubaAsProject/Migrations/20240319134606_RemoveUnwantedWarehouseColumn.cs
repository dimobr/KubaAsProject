using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KubaAsProject.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnwantedWarehouseColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warehouses_WarehouseId1",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_WarehouseId1",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "WarehouseId1",
                table: "Inventory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId1",
                table: "Inventory",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                column: "WarehouseId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_WarehouseId1",
                table: "Inventory",
                column: "WarehouseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warehouses_WarehouseId1",
                table: "Inventory",
                column: "WarehouseId1",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }
    }
}
