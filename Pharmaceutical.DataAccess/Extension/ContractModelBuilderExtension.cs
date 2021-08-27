using Microsoft.EntityFrameworkCore;
using Pharmaceutical.Common.Models;

namespace Pharmaceutical.DAL.Extension
{
    public static class ContractModelBuilderExtension
    {
        public static void SeedContractData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractDetail>().HasData(
                new ContractDetail
                {
                    ContractId = 101,
                    Id = 1,
                    ContractName = "Contract101",
                    AssignedBy = "ToddPharmaceutical",
                    IsCompanyApproved = true,
                    IsVendorContractApproved = false,
                    ApprovedDate = System.DateTime.Now,
                    AssignedDate = null
                },
                new ContractDetail
                {
                    ContractId = 101,
                    Id = 2,
                    ContractName = "Contract101",
                    AssignedBy = "ToddPharmaceutical",
                    IsCompanyApproved = false,
                    IsVendorContractApproved = false,
                    ApprovedDate = null,
                    AssignedDate = null
                },
                new ContractDetail
                {
                    ContractId = 102,
                    Id = 3,
                    ContractName = "Contract102",
                    AssignedBy = "ToddPharmaceutical",
                    IsCompanyApproved = true,
                    IsVendorContractApproved = true,
                    ApprovedDate = System.DateTime.Now.AddDays(-1),
                    AssignedDate = System.DateTime.Now
                },
                new ContractDetail
                {
                    ContractId = 102,
                    Id = 4,
                    ContractName = "Contract102",
                    AssignedBy = "ToddPharmaceutical",
                    IsCompanyApproved = false,
                    IsVendorContractApproved = false,
                    ApprovedDate = null,
                    AssignedDate = null
                });

        }
    }
}
