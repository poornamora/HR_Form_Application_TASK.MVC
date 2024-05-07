using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_Sample_Project.Migrations
{
    /// <inheritdoc />
    public partial class FKRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_City",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cities_City",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "City",
                table: "cities");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "HRFormModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HRFormModels_CityId",
                table: "HRFormModels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryId",
                table: "cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries_CountryId",
                table: "cities",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HRFormModels_cities_CityId",
                table: "HRFormModels",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_CountryId",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_HRFormModels_cities_CityId",
                table: "HRFormModels");

            migrationBuilder.DropIndex(
                name: "IX_HRFormModels_CityId",
                table: "HRFormModels");

            migrationBuilder.DropIndex(
                name: "IX_cities_CountryId",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "HRFormModels");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "cities");

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_City",
                table: "cities",
                column: "City");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries_City",
                table: "cities",
                column: "City",
                principalTable: "countries",
                principalColumn: "CountryId");
        }
    }
}
