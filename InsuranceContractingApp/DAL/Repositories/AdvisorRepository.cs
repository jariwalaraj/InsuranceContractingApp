using InsuranceContractingAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL.Repositories
{
    public interface IAdvisorRepository
    {
        List<Advisors> GetAdvisors();

        Advisors GetAdvisorsById(int id);

        Advisors UpdateAdvisors(Advisors advisors);
    }
    public class AdvisorRepository : IAdvisorRepository
    {
        private ICDbContext gICDbContext; 
        public AdvisorRepository(ICDbContext iCDbContext)
        {
            gICDbContext = iCDbContext;
        }

        public List<Advisors> GetAdvisors()
        {
            return gICDbContext.Advisors.ToList();
        }

        public Advisors GetAdvisorsById(int id)
        {
            return gICDbContext.Advisors.Where(c=>c.AdvisorsId == id).FirstOrDefault();
        }

        public Advisors UpdateAdvisors(Advisors advisors)
        {
            gICDbContext.Advisors.Update(advisors);

            try
            {
                gICDbContext.SaveChanges();
            }
            catch (Exception e)
            { 
                return null; 
            }

            return advisors;
        }
    }
}
