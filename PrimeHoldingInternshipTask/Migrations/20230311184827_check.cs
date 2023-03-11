using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeHoldingInternshipTask.Migrations
{
    /// <inheritdoc />
    public partial class check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Tasks",
                newName: "AsigneeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                newName: "IX_Tasks_AsigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_AsigneeId",
                table: "Tasks",
                column: "AsigneeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_AsigneeId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "AsigneeId",
                table: "Tasks",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AsigneeId",
                table: "Tasks",
                newName: "IX_Tasks_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
