﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceAPP.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathToProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Produits",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Produits");
        }
    }
}
