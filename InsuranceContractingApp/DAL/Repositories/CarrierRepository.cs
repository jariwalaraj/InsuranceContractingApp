using InsuranceContractingAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceContractingAPI.DAL.Repositories
{
    public interface ICarrierRepository
    {
        List<Carriers> GetCarriers();

        Carriers GetCarrierById(int id);

        Carriers UpdateCarriers(Carriers advisors);
    }
    public class CarrierRepository : ICarrierRepository
    {
        private ICDbContext gICDbContext; 
        public CarrierRepository(ICDbContext iCDbContext)
        {
            gICDbContext = iCDbContext;
        }

        public List<Carriers> GetCarriers()
        {
            return gICDbContext.Carriers.ToList();
        }

        public Carriers GetCarrierById(int id)
        {
            return gICDbContext.Carriers.Where(c=>c.CarrierId == id).FirstOrDefault();
        }

        public Carriers UpdateCarriers(Carriers carriers)
        {
            gICDbContext.Carriers.Update(carriers);

            try
            {
                gICDbContext.SaveChanges();
            }
            catch (Exception e)
            { 
                return null; 
            }

            return carriers;
        }
    }
}
