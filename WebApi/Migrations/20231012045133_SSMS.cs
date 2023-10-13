using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SSMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "Employees",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Employees",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "company",
                table: "Employees",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Employees",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Employees",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Employees",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Employees",
                newName: "company");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Employees",
                newName: "city");
        }
    }
}
