using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmaceutical.Common.Models
{
    public class ContractDetail
    {                
        [Key]
        public int Id { get; set; }
        public int ContractId { get; set; }
        public string ContractName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string AssignedBy { get; set; }
        public DateTime? AssignedDate { get; set; }
        public bool IsCompanyApproved { get; set; }
        public bool IsVendorContractApproved { get; set; }
    }
}
