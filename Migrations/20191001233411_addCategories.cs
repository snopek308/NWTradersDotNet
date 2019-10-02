using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace Northwind.Migrations
{
    public partial class addCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // FROM FILE
            var sqlFile = Path.Combine
                (AppDomain.CurrentDomain.BaseDirectory, "Migrations", "Sql",
                @"Northwind_Categories.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
