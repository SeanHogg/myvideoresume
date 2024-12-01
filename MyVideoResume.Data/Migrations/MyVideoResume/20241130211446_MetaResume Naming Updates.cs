using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class MetaResumeNamingUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JSONResumes_MetaResume_ResumeStructureId",
                table: "JSONResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_JSONResumes_UserAccounts_UserAccountEntityId",
                table: "JSONResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_JSONResumes_JSONResumeFormatId",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JSONResumes",
                table: "JSONResumes");

            migrationBuilder.RenameTable(
                name: "JSONResumes",
                newName: "MetaResumes");

            migrationBuilder.RenameIndex(
                name: "IX_JSONResumes_UserAccountEntityId",
                table: "MetaResumes",
                newName: "IX_MetaResumes_UserAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_JSONResumes_ResumeStructureId",
                table: "MetaResumes",
                newName: "IX_MetaResumes_ResumeStructureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetaResumes",
                table: "MetaResumes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_MetaResume_ResumeStructureId",
                table: "MetaResumes",
                column: "ResumeStructureId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_UserAccounts_UserAccountEntityId",
                table: "MetaResumes",
                column: "UserAccountEntityId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_MetaResumes_JSONResumeFormatId",
                table: "Resumes",
                column: "JSONResumeFormatId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_MetaResume_ResumeStructureId",
                table: "MetaResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_UserAccounts_UserAccountEntityId",
                table: "MetaResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_MetaResumes_JSONResumeFormatId",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetaResumes",
                table: "MetaResumes");

            migrationBuilder.RenameTable(
                name: "MetaResumes",
                newName: "JSONResumes");

            migrationBuilder.RenameIndex(
                name: "IX_MetaResumes_UserAccountEntityId",
                table: "JSONResumes",
                newName: "IX_JSONResumes_UserAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaResumes_ResumeStructureId",
                table: "JSONResumes",
                newName: "IX_JSONResumes_ResumeStructureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JSONResumes",
                table: "JSONResumes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JSONResumes_MetaResume_ResumeStructureId",
                table: "JSONResumes",
                column: "ResumeStructureId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JSONResumes_UserAccounts_UserAccountEntityId",
                table: "JSONResumes",
                column: "UserAccountEntityId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_JSONResumes_JSONResumeFormatId",
                table: "Resumes",
                column: "JSONResumeFormatId",
                principalTable: "JSONResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
