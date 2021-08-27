using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmaceutical.DAL.Migrations
{
    public partial class SeedContractTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    ContractName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompanyApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsVendorContractApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContractDetails",
                columns: new[] { "Id", "ApprovedDate", "AssignedBy", "AssignedDate", "ContractId", "ContractName", "IsCompanyApproved", "IsVendorContractApproved" },
                values: new object[] { 100, null, "ToddPharmaceutical", null, 1, "Contract100", false, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractDetails");
        }
    }
}
