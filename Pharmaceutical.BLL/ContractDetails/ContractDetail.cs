using Microsoft.AspNetCore.Http;
using Pharmaceutical.BLL.IContractDetails;
using Pharmaceutical.Common.Helper;
using System.Collections.Generic;
using System.Linq;
using MODEL = Pharmaceutical.Common.Models;
using REPO = Pharmaceutical.Abstraction.IRepository;

namespace Pharmaceutical.BLL.ContractDetails
{
    public class ContractDetail : IContractDetail
    {
        private readonly REPO.IContractRepository _contractRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContractDetail(REPO.IContractRepository contractRepository, IHttpContextAccessor httpContextAccessor)
        {
            _contractRepository = contractRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public MODEL.ContractDetail CreateContractDetails(MODEL.ContractDetail contractDetail)
        {
            return _contractRepository.CreateContractDetails(contractDetail);
        }

        public MODEL.ContractDetail DeleteContractDetail(int ContractId)
        {
            return _contractRepository.DeleteContractDetail(ContractId);
        }

        public List<MODEL.ContractDetail> GetContractDetails()
        {
            ClaimsHelper.FindUserType(_httpContextAccessor, out int contractId);
            
            List<MODEL.ContractDetail> contractDetails;
            if (contractId > 0)
                contractDetails = GetContractDetailsById(contractId);
            else
                contractDetails = _contractRepository.GetContractDetails().ToList();
            return contractDetails;
        }

        public List<MODEL.ContractDetail> GetContractDetailsById(int contractId)
        {
            return _contractRepository.GetContractDetails().ToList().FindAll(x => x.ContractId == contractId);

        }

        public MODEL.ContractDetail UpdateContractDetail(MODEL.ContractDetail contractDetail)
        {
            return _contractRepository.UpdateContractDetail(contractDetail);
        }
    }
}
