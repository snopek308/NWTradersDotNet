using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Northwind.Migrations
{
    //changed the inhertiance here
    public partial class PopulateDiscounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)

        {
            var sqlFile = System.IO.Path.Combine
                (System.AppDomain.CurrentDomain.BaseDirectory, "../../../", "Migrations", "Sql",
                @"Populate_Discounts.sql");
        migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

    protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
