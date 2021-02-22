using InsuranceContractingAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL.Repositories
{
    public interface IContractorsRepository
    {
        List<Contractors> GetAllContractors();
        Contractors GetContractorsById(int id);

        Contractors AddContractor(Contractors advisors);
    }
    public class ContractorsRepository : IContractorsRepository
    {
        private ICDbContext gICDbContext; 
        public ContractorsRepository(ICDbContext iCDbContext)
        {
            gICDbContext = iCDbContext;
        }

        public List<Contractors> GetAllContractors()
        {
            return gICDbContext.Contractors?.ToList();
        }
        public Contractors GetContractorsById(int id)
        {
            return gICDbContext.Contractors.Where(c=>c.ContractorId == id).FirstOrDefault();
        }

        public Contractors AddContractor(Contractors contractor)
        {
            gICDbContext.Contractors.Add(contractor);

            try
            {
                gICDbContext.SaveChanges();
            }
            catch (Exception e)
            { 
                return null; 
            }

            return contractor;
        }

    }
}
