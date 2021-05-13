using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreAssortment.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StoreAssortmentItems",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("3873c080-9a02-4891-a316-f07a776f71cf"), "Delikata frysta kycklingspett marinerade i chilisås", "Kycklingspett", 100m },
                    { new Guid("dff3bd4f-7629-440f-882d-90c466b74860"), "God lasagne", "Lasagne", 70m },
                    { new Guid("85ca08be-fe9e-4e42-822e-af188fb62209"), "Vacker tårta med tre lager glass på en god nötbotten", "Glasstårta", 150m },
                    { new Guid("b246cc1b-ee71-4ae6-9cc1-4dfc2ab15946"), "Smulig äppelpaj som är magiskt god", "Äppelpaj", 140m },
                    { new Guid("7cbdf4e6-60a2-45de-a3b3-8de8c9c52837"), "Finskuren pyttipanna", "Pyttipanna", 90m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoreAssortmentItems",
                keyColumn: "Id",
                keyValue: new Guid("3873c080-9a02-4891-a316-f07a776f71cf"));

            migrationBuilder.DeleteData(
                table: "StoreAssortmentItems",
                keyColumn: "Id",
                keyValue: new Guid("7cbdf4e6-60a2-45de-a3b3-8de8c9c52837"));

            migrationBuilder.DeleteData(
                table: "StoreAssortmentItems",
                keyColumn: "Id",
                keyValue: new Guid("85ca08be-fe9e-4e42-822e-af188fb62209"));

            migrationBuilder.DeleteData(
                table: "StoreAssortmentItems",
                keyColumn: "Id",
                keyValue: new Guid("b246cc1b-ee71-4ae6-9cc1-4dfc2ab15946"));

            migrationBuilder.DeleteData(
                table: "StoreAssortmentItems",
                keyColumn: "Id",
                keyValue: new Guid("dff3bd4f-7629-440f-882d-90c466b74860"));
        }
    }
}
