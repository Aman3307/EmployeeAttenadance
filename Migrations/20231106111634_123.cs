using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAttenadance.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: false),
                    ModifiedByUsername = table.Column<string>(nullable: true),
                    ModifiedOnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AId);
                });

            migrationBuilder.CreateTable(
                name: "EmpDetails",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Dept = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: false),
                    ModifiedBYUsername = table.Column<string>(nullable: true),
                    ModifiedOnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpDetails", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "EmpSalaryDetails",
                columns: table => new
                {
                    SdId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basic = table.Column<decimal>(nullable: false),
                    HRA = table.Column<decimal>(nullable: false),
                    Others = table.Column<decimal>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    TsId = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: false),
                    ModifiedByUsername = table.Column<string>(nullable: true),
                    ModifiedOnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpSalaryDetails", x => x.SdId);
                });

            migrationBuilder.CreateTable(
                name: "EmpTotalSalary",
                columns: table => new
                {
                    TsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSalary = table.Column<decimal>(nullable: false),
                    EmpId = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: false),
                    ModifiedByUsername = table.Column<string>(nullable: true),
                    ModifiedOnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpTotalSalary", x => x.TsId);
                });

            migrationBuilder.CreateTable(
                name: "UserCredentials",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentials", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "EmpDetails");

            migrationBuilder.DropTable(
                name: "EmpSalaryDetails");

            migrationBuilder.DropTable(
                name: "EmpTotalSalary");

            migrationBuilder.DropTable(
                name: "UserCredentials");
        }
    }
}
