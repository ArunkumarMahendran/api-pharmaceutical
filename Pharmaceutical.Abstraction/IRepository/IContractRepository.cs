using Pharmaceutical.Common.Models;
using System.Linq;

namespace Pharmaceutical.Abstraction.IRepository
{
    public interface IContractRepository
    {
        ContractDetail CreateContractDetails(ContractDetail contractDetail);
        IQueryable<ContractDetail> GetContractDetails();
        ContractDetail UpdateContractDetail(ContractDetail contractDetail);
        ContractDetail DeleteContractDetail(int id);       
    }
}
