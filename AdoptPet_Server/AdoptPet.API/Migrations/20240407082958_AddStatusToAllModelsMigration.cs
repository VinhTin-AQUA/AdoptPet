using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptPet.API.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToAllModelsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Volunteers",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "VolunteerRoleXVolunteers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "VolunteerRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "VolunteerAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PetImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PetColours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PetBreeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "PetAudits",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DonorPets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DonorPetAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Colours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Breeds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "VolunteerRoleXVolunteers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "VolunteerRoles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "VolunteerAudits");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PetImages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PetColours");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PetBreeds");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DonorPets");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DonorPetAudits");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Colours");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Breeds");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Volunteers",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "PetAudits",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
