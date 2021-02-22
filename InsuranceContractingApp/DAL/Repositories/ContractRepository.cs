using InsuranceContractingAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL.Repositories
{
    public interface IContractRepository
    {
        List<Contracts> GetAllContracts();
        bool DoesDirectContractExistAlready(int id1, int id2);
        bool EstablishContract(int ContractorEntityA, int ContractorEntityB);
        bool TerminateContract(int contractId);
    }
    public class ContractRepository : IContractRepository
    {
        private ICDbContext gICDbContext;
        public ContractRepository(ICDbContext iCDbContext)
        {
            gICDbContext = iCDbContext;
        }

        public List<Contracts> GetAllContracts()
        {
            return gICDbContext.Contracts.Where(c => !c.IsTerminated)?.ToList();
        }

        public bool DoesDirectContractExistAlready(int id1, int id2)
        {
            return gICDbContext.Contracts
                .Count(c => 
                        ((c.ContractorIdA == id1 && c.ContractorIdB == id2) || 
                        (c.ContractorIdA == id2 && c.ContractorIdB == id1)) 
                        && !c.IsTerminated) > 0;
        }

        public bool TerminateContract(int contractId)
        {
            bool response = false;

            Contracts contracts = new Contracts()
            {
                ContractId = contractId,
                TerminationDate = DateTime.Now,
                IsTerminated = true
            };

            gICDbContext.Contracts.Update(contracts);


            try
            {
                gICDbContext.SaveChanges();
                response = true;
            }
            catch(Exception)
            { }

            return response;
        }

        public bool EstablishContract(int ContractorEntityA, int ContractorEntityB)
        {
            bool response = false;
            Contracts contracts = new Contracts() 
            { 
                ContractorIdA = ContractorEntityA, 
                ContractorIdB = ContractorEntityB, 
                CreationDate = DateTime.UtcNow
            };

            gICDbContext.Contracts.Add(contracts);
            
            try
            {
                gICDbContext.SaveChanges();
                response = true;
            }
            catch (Exception)
            {
                
            }

            return response;
        }

    }

}
