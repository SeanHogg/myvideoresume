using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class OrderResumeItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Work",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Volunteer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Skill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ReferenceItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Publication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublic",
                table: "MetaResumes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "LanguageItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Interest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Certificate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Award",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ReferenceItem");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "LanguageItem");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Interest");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Award");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublic",
                table: "MetaResumes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
