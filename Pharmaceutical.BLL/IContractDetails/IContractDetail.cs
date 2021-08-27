using MODEL = Pharmaceutical.Common.Models;
using System.Collections.Generic;

namespace Pharmaceutical.BLL.IContractDetails
{
    public interface IContractDetail
    {
        MODEL.ContractDetail CreateContractDetails(MODEL.ContractDetail contractDetail);
        List<MODEL.ContractDetail> GetContractDetails();
        MODEL.ContractDetail UpdateContractDetail(MODEL.ContractDetail contractDetail);
        MODEL.ContractDetail DeleteContractDetail(int ContractId);
        List<MODEL.ContractDetail> GetContractDetailsById(int contractId);
    }
}
