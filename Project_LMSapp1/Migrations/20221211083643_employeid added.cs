using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_LMSapp1.Migrations
{
    public partial class employeidadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "LoginPage");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "LoginPage",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "LoginPage");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "LoginPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
