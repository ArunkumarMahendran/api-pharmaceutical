using Pharmaceutical.Abstraction.IRepository;
using Pharmaceutical.Common.Models;
using Pharmaceutical.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pharmaceutical.Abstraction.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly ApplicationDBContext _context;

        public ContractRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public ContractDetail CreateContractDetails(ContractDetail contractDetail)
        {
            _context.Add(contractDetail);
            _context.SaveChanges();
            return contractDetail;
        }

        public ContractDetail DeleteContractDetail(int id)
        {
            var contractDetail = _context.ContractDetails.Find(id);
            if (contractDetail != null)
            {
                _context.ContractDetails.Remove(contractDetail);
                _context.SaveChanges();
            }
            return contractDetail;
        }

        public IQueryable<ContractDetail> GetContractDetails()
        {
            return _context.ContractDetails;
        }

        public ContractDetail UpdateContractDetail(ContractDetail contractDetail)
        {
            var updateContractDetail = _context.ContractDetails.Attach(contractDetail);
            updateContractDetail.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return contractDetail;
        }
    }
}
