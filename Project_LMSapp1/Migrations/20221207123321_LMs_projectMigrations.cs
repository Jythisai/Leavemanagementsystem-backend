using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_LMSapp1.Migrations
{
    public partial class LMs_projectMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyLeave",
                columns: table => new
                {
                    LeaveApplicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDays = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    LeaveType = table.Column<string>(nullable: true),
                    LeaveReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyLeave", x => x.LeaveApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    MobileNo = table.Column<long>(nullable: false),
                    EmailId = table.Column<string>(nullable: false),
                    DateJoined = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: false),
                    ManagerName = table.Column<string>(nullable: false),
                    Salary = table.Column<float>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyLeave");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
