using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class MetaResumeRelationshipUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_UserAccounts_UserAccountEntityId",
                table: "MetaResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_MetaResumes_JSONResumeFormatId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_MetaResumes_UserAccountEntityId",
                table: "MetaResumes");

            migrationBuilder.DropColumn(
                name: "UserAccountEntityId",
                table: "MetaResumes");

            migrationBuilder.RenameColumn(
                name: "JSONResumeFormatId",
                table: "Resumes",
                newName: "ResumeFormatId");

            migrationBuilder.RenameIndex(
                name: "IX_Resumes_JSONResumeFormatId",
                table: "Resumes",
                newName: "IX_Resumes_ResumeFormatId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAccountEntityId",
                table: "Resumes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_UserAccountEntityId",
                table: "Resumes",
                column: "UserAccountEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_MetaResumes_ResumeFormatId",
                table: "Resumes",
                column: "ResumeFormatId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_UserAccounts_UserAccountEntityId",
                table: "Resumes",
                column: "UserAccountEntityId",
                principalTable: "UserAccounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_MetaResumes_ResumeFormatId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_UserAccounts_UserAccountEntityId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_UserAccountEntityId",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "UserAccountEntityId",
                table: "Resumes");

            migrationBuilder.RenameColumn(
                name: "ResumeFormatId",
                table: "Resumes",
                newName: "JSONResumeFormatId");

            migrationBuilder.RenameIndex(
                name: "IX_Resumes_ResumeFormatId",
                table: "Resumes",
                newName: "IX_Resumes_JSONResumeFormatId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAccountEntityId",
                table: "MetaResumes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetaResumes_UserAccountEntityId",
                table: "MetaResumes",
                column: "UserAccountEntityId");

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
    }
}
