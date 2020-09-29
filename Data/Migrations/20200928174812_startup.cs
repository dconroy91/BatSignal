using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneBatSignal.Data.Migrations
{
    public partial class startup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CohortId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsInstructor",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cohort",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cohort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentUserId = table.Column<string>(nullable: true),
                    InstructorUserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    IsTutoring = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CohortId",
                table: "AspNetUsers",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_InstructorUserId",
                table: "Requests",
                column: "InstructorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentUserId",
                table: "Requests",
                column: "StudentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers",
                column: "CohortId",
                principalTable: "Cohort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cohort");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CohortId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CohortId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsInstructor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
