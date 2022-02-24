using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Net6.Web.Minimum.Context.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExampleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExampleEntity",
                columns: new[] { "Id", "Created", "Guid" },
                values: new object[] { 1, new DateTime(2022, 2, 23, 8, 54, 52, 153, DateTimeKind.Local).AddTicks(1525), new Guid("342acca1-55a1-47e0-8df4-c5c5387c784a") });

            migrationBuilder.InsertData(
                table: "ExampleEntity",
                columns: new[] { "Id", "Created", "Guid" },
                values: new object[] { 2, new DateTime(2022, 2, 23, 8, 54, 52, 153, DateTimeKind.Local).AddTicks(1576), new Guid("391d31e8-1aa3-404e-824a-c964f4116ae5") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleEntity");
        }
    }
}
