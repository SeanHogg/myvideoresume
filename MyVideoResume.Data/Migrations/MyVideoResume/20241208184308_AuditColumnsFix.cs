using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class AuditColumnsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "UserProfiles",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "UserProfiles",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "UserProfiles",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "ResumeTemplates",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "ResumeTemplates",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "ResumeTemplates",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "ResumeInformation",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "ResumeInformation",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "ResumeInformation",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "MetaData",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "MetaData",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "MetaData",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Jobs",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "Jobs",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Jobs",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "JobPreferences",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "JobPreferences",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "JobPreferences",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Companies",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "Companies",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Companies",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "ApplicantToJob",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "ApplicantToJob",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "ApplicantToJob",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Addresses",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "Addresses",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Addresses",
                newName: "CreationDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "UserProfiles",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "UserProfiles",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "UserProfiles",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "ResumeTemplates",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "ResumeTemplates",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "ResumeTemplates",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "ResumeInformation",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "ResumeInformation",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "ResumeInformation",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "MetaData",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "MetaData",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "MetaData",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "Jobs",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "Jobs",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "Jobs",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "JobPreferences",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "JobPreferences",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "JobPreferences",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "Companies",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "Companies",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "Companies",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "ApplicantToJob",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "ApplicantToJob",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "ApplicantToJob",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "Addresses",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "Addresses",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "Addresses",
                newName: "CreationDate");
        }
    }
}
