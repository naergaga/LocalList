using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LocalList.Migrations
{
    public partial class Project_Name_Index_Unique_Add_Title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Project_Name",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_Name",
                table: "Project",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Project_Name",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Project");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Project_Name",
                table: "Project",
                column: "Name");
        }
    }
}
