using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Shopping.Data.Migrations
{
    public partial class Configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Email", "INN", "Name", "Password", "Phone", "Region", "Status" },
                values: new object[] { new Guid("527458d1-e742-4498-3ef0-08d9915d00a9"), "Bo`ston tumani", "jasurbuz@gmail.com", "5165653131", "Jasurbek Xasanboyev", "123456789", "+998936909007", "Andijon", "Yuridik" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Count", "Description", "Name", "Price" },
                values: new object[] { new Guid("3aeb62d1-9387-4b1a-94d1-19a596eb703d"), 10, "Qizil olma", "Olma", 12000.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Count", "Description", "Name", "Price" },
                values: new object[] { new Guid("ca37ae78-feb1-44b4-807a-8e266efd8afa"), 10, "Tukli shaftoli", "Shaftoli", 10000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("527458d1-e742-4498-3ef0-08d9915d00a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3aeb62d1-9387-4b1a-94d1-19a596eb703d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca37ae78-feb1-44b4-807a-8e266efd8afa"));
        }
    }
}
