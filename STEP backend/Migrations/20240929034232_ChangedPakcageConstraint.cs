using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STEP_backend.Migrations
{
    public partial class ChangedPakcageConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_StudentId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Packages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_StudentId",
                table: "Packages",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_StudentId",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Packages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Packages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_StudentId",
                table: "Packages",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
