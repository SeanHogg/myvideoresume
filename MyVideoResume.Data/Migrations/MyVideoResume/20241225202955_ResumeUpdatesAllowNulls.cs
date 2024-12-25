using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class ResumeUpdatesAllowNulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MetaResumes_Resume",
                table: "MetaResumes");

            migrationBuilder.AlterColumn<Guid>(
                name: "Resume",
                table: "MetaResumes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_MetaResumes_Resume",
                table: "MetaResumes",
                column: "Resume",
                unique: true,
                filter: "[Resume] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MetaResumes_Resume",
                table: "MetaResumes");

            migrationBuilder.AlterColumn<Guid>(
                name: "Resume",
                table: "MetaResumes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetaResumes_Resume",
                table: "MetaResumes",
                column: "Resume",
                unique: true);
        }
    }
}
