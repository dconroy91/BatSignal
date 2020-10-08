using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneBatSignal.Data.Migrations
{
    public partial class changedCohortRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CohortId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers",
                column: "CohortId",
                principalTable: "Cohort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CohortId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers",
                column: "CohortId",
                principalTable: "Cohort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
