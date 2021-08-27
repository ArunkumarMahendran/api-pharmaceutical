using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmaceutical.DAL.Migrations
{
    public partial class SeedMultipleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContractDetails",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.InsertData(
                table: "ContractDetails",
                columns: new[] { "Id", "ApprovedDate", "AssignedBy", "AssignedDate", "ContractId", "ContractName", "IsCompanyApproved", "IsVendorContractApproved" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 19, 22, 11, 16, 163, DateTimeKind.Local).AddTicks(2162), "ToddPharmaceutical", null, 101, "Contract101", true, false },
                    { 2, null, "ToddPharmaceutical", null, 101, "Contract101", false, false },
                    { 3, new DateTime(2021, 8, 18, 22, 11, 16, 165, DateTimeKind.Local).AddTicks(3822), "ToddPharmaceutical", new DateTime(2021, 8, 19, 22, 11, 16, 165, DateTimeKind.Local).AddTicks(4152), 102, "Contract102", true, true },
                    { 4, null, "ToddPharmaceutical", null, 102, "Contract102", false, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContractDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContractDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContractDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContractDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "ContractDetails",
                columns: new[] { "Id", "ApprovedDate", "AssignedBy", "AssignedDate", "ContractId", "ContractName", "IsCompanyApproved", "IsVendorContractApproved" },
                values: new object[] { 100, null, "ToddPharmaceutical", null, 1, "Contract100", false, false });
        }
    }
}
