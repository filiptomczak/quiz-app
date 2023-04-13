﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizTerenowyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCtorToPlaceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Places_PlaceId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Places_PlaceId",
                table: "Questions",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Places_PlaceId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Places_PlaceId",
                table: "Questions",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");
        }
    }
}
