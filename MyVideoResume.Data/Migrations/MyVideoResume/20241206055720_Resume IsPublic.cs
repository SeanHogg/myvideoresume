using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class ResumeIsPublic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_ResumeInformation_ResumeInformationId",
                table: "MetaResumes");

            migrationBuilder.DropIndex(
                name: "IX_MetaResumes_ResumeInformationId",
                table: "MetaResumes");

            migrationBuilder.RenameColumn(
                name: "ResumeInformationId",
                table: "MetaResumes",
                newName: "Resume");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "ResumeInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "MetaResumes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserHandle",
                table: "JobPreferences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetaResumes_Resume",
                table: "MetaResumes",
                column: "Resume",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_ResumeInformation_Resume",
                table: "MetaResumes",
                column: "Resume",
                principalTable: "ResumeInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_ResumeInformation_Resume",
                table: "MetaResumes");

            migrationBuilder.DropIndex(
                name: "IX_MetaResumes_Resume",
                table: "MetaResumes");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "ResumeInformation");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "MetaResumes");

            migrationBuilder.DropColumn(
                name: "UserHandle",
                table: "JobPreferences");

            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "MetaResumes",
                newName: "ResumeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaResumes_ResumeInformationId",
                table: "MetaResumes",
                column: "ResumeInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_ResumeInformation_ResumeInformationId",
                table: "MetaResumes",
                column: "ResumeInformationId",
                principalTable: "ResumeInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
