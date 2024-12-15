using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class JobApplicants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantToJob_MetaResumes_UserResumeId",
                table: "ApplicantToJob");

            migrationBuilder.RenameColumn(
                name: "UserResumeId",
                table: "ApplicantToJob",
                newName: "ResumeItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantToJob_UserResumeId",
                table: "ApplicantToJob",
                newName: "IX_ApplicantToJob_ResumeItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantToJob_ResumeInformation_ResumeItemId",
                table: "ApplicantToJob",
                column: "ResumeItemId",
                principalTable: "ResumeInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantToJob_ResumeInformation_ResumeItemId",
                table: "ApplicantToJob");

            migrationBuilder.RenameColumn(
                name: "ResumeItemId",
                table: "ApplicantToJob",
                newName: "UserResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantToJob_ResumeItemId",
                table: "ApplicantToJob",
                newName: "IX_ApplicantToJob_UserResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantToJob_MetaResumes_UserResumeId",
                table: "ApplicantToJob",
                column: "UserResumeId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
