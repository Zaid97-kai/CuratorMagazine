using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuratorMagazineWebAPI.Migrations
{
    public partial class FixFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Divisions_IdDivision",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Parents_IdFather",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Parents_IdMother",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdDivision",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdFather",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdDivision",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdFather",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Users",
                newName: "DivisionId");

            migrationBuilder.RenameColumn(
                name: "IdMother",
                table: "Users",
                newName: "MotherId");

            migrationBuilder.RenameColumn(
                name: "IdGroup",
                table: "Users",
                newName: "FatherId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdMother",
                table: "Users",
                newName: "IX_Users_MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DivisionId",
                table: "Users",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FatherId",
                table: "Users",
                column: "FatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Divisions_DivisionId",
                table: "Users",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Parents_FatherId",
                table: "Users",
                column: "FatherId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Parents_MotherId",
                table: "Users",
                column: "MotherId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Divisions_DivisionId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Parents_FatherId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Parents_MotherId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DivisionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FatherId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "MotherId",
                table: "Users",
                newName: "IdMother");

            migrationBuilder.RenameColumn(
                name: "FatherId",
                table: "Users",
                newName: "IdGroup");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Users",
                newName: "IdRole");

            migrationBuilder.RenameIndex(
                name: "IX_Users_MotherId",
                table: "Users",
                newName: "IX_Users_IdMother");

            migrationBuilder.AddColumn<int>(
                name: "IdDivision",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFather",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdDivision",
                table: "Users",
                column: "IdDivision");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdFather",
                table: "Users",
                column: "IdFather");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Divisions_IdDivision",
                table: "Users",
                column: "IdDivision",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Parents_IdFather",
                table: "Users",
                column: "IdFather",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Parents_IdMother",
                table: "Users",
                column: "IdMother",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
