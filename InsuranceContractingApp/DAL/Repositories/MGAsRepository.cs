using InsuranceContractingAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL.Repositories
{
    public interface IMGAsRepository
    {
        List<MGAs> GetMGAs();

        MGAs GetMGAsById(int id);

        MGAs UpdateMGAs(MGAs advisors);

        MGAs InsertMGAs(MGAs MGA); 
    }
    public class MGAsRepository : IMGAsRepository
    {
        private ICDbContext gICDbContext; 
        public MGAsRepository(ICDbContext iCDbContext)
        {
            gICDbContext = iCDbContext;
        }

        public List<MGAs> GetMGAs()
        {
            return gICDbContext.MGAs.ToList();
        }

        public MGAs InsertMGAs(MGAs newMGA)
        {
            if (newMGA == null) return null;

            gICDbContext.MGAs.Add(newMGA);
            try
            {
                gICDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }

            return newMGA;
        }
        public MGAs GetMGAsById(int id)
        {
            return gICDbContext.MGAs.Where(c=>c.MGAId == id).FirstOrDefault();
        }

        public MGAs UpdateMGAs(MGAs mGAs)
        {
            gICDbContext.MGAs.Update(mGAs);

            try
            {
                gICDbContext.SaveChanges();
            }
            catch (Exception e)
            { 
                return null; 
            }

            return mGAs;
        }
    }
}
