using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApi.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Age",
                table: "Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "FavoriteShopId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrderCount",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "DeliveredOrderCount",
                table: "Shops",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrderCount",
                table: "Shops",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Producer",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductPicture",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Users_FavoriteShopId",
                table: "Users",
                column: "FavoriteShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Shops_FavoriteShopId",
                table: "Users",
                column: "FavoriteShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Shops_FavoriteShopId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FavoriteShopId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FavoriteShopId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrderCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeliveredOrderCount",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "OrderCount",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Producer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPicture",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
