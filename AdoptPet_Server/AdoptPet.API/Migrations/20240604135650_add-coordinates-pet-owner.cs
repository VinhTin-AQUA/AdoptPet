using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptPet.API.Migrations
{
    /// <inheritdoc />
    public partial class addcoordinatespetowner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "colourId",
                table: "Pets",
                newName: "ColourId");

            migrationBuilder.RenameColumn(
                name: "breedId",
                table: "Pets",
                newName: "BreedId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_colourId",
                table: "Pets",
                newName: "IX_Pets_ColourId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_breedId",
                table: "Pets",
                newName: "IX_Pets_BreedId");

            migrationBuilder.AlterColumn<string>(
                name: "PetDescription",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Pets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Pets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Owners",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Owners",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Owners");

            migrationBuilder.RenameColumn(
                name: "ColourId",
                table: "Pets",
                newName: "colourId");

            migrationBuilder.RenameColumn(
                name: "BreedId",
                table: "Pets",
                newName: "breedId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ColourId",
                table: "Pets",
                newName: "IX_Pets_colourId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_BreedId",
                table: "Pets",
                newName: "IX_Pets_breedId");

            migrationBuilder.AlterColumn<string>(
                name: "PetDescription",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

        }
    }
}
