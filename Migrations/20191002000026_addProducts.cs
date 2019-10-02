﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace Northwind.Migrations
{
    public partial class addProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // FROM FILE
            var sqlFile = Path.Combine
                (AppDomain.CurrentDomain.BaseDirectory, "Migrations", "Sql",
                @"Northwind_Products.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
