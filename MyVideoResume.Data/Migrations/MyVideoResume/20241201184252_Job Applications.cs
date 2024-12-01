using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class JobApplications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_UserAccounts_UserAccountEntityId",
                table: "MetaResumes");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.RenameColumn(
                name: "UserAccountEntityId",
                table: "MetaResumes",
                newName: "UserProfileEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaResumes_UserAccountEntityId",
                table: "MetaResumes",
                newName: "IX_MetaResumes_UserProfileEntityId");

            migrationBuilder.AddColumn<Guid>(
                name: "ResumeTemplateId",
                table: "MetaResumes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Latitude = table.Column<int>(type: "int", nullable: true),
                    Longitude = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransformerComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MailingAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillingAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermsOfUseAgreementAcceptedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TermsOfUserAgreementVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_MailingAddressId",
                        column: x => x.MailingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPreferencesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MailingAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BillingAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Addresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProfiles_Addresses_MailingAddressId",
                        column: x => x.MailingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProfiles_JobPreferences_JobPreferencesId",
                        column: x => x.JobPreferencesId,
                        principalTable: "JobPreferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantToJob",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserApplyingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobApplicationStatus = table.Column<int>(type: "int", nullable: false),
                    MatchResults = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchResultsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchScoreRating = table.Column<float>(type: "real", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantToJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantToJob_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantToJob_MetaResumes_UserResumeId",
                        column: x => x.UserResumeId,
                        principalTable: "MetaResumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantToJob_UserProfiles_UserApplyingId",
                        column: x => x.UserApplyingId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetaResumes_ResumeTemplateId",
                table: "MetaResumes",
                column: "ResumeTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantToJob_JobId",
                table: "ApplicantToJob",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantToJob_UserApplyingId",
                table: "ApplicantToJob",
                column: "UserApplyingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantToJob_UserResumeId",
                table: "ApplicantToJob",
                column: "UserResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BillingAddressId",
                table: "Companies",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_MailingAddressId",
                table: "Companies",
                column: "MailingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_BillingAddressId",
                table: "UserProfiles",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_JobPreferencesId",
                table: "UserProfiles",
                column: "JobPreferencesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_MailingAddressId",
                table: "UserProfiles",
                column: "MailingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_ResumeTemplates_ResumeTemplateId",
                table: "MetaResumes",
                column: "ResumeTemplateId",
                principalTable: "ResumeTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_UserProfiles_UserProfileEntityId",
                table: "MetaResumes",
                column: "UserProfileEntityId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_ResumeTemplates_ResumeTemplateId",
                table: "MetaResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_UserProfiles_UserProfileEntityId",
                table: "MetaResumes");

            migrationBuilder.DropTable(
                name: "ApplicantToJob");

            migrationBuilder.DropTable(
                name: "ResumeTemplates");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_MetaResumes_ResumeTemplateId",
                table: "MetaResumes");

            migrationBuilder.DropColumn(
                name: "ResumeTemplateId",
                table: "MetaResumes");

            migrationBuilder.RenameColumn(
                name: "UserProfileEntityId",
                table: "MetaResumes",
                newName: "UserAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaResumes_UserProfileEntityId",
                table: "MetaResumes",
                newName: "IX_MetaResumes_UserAccountEntityId");

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPreferencesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_JobPreferences_JobPreferencesId",
                        column: x => x.JobPreferencesId,
                        principalTable: "JobPreferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_JobPreferencesId",
                table: "UserAccounts",
                column: "JobPreferencesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_UserAccounts_UserAccountEntityId",
                table: "MetaResumes",
                column: "UserAccountEntityId",
                principalTable: "UserAccounts",
                principalColumn: "Id");
        }
    }
}
