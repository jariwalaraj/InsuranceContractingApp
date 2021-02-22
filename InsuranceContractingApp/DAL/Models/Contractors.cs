using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL.Models
{
    public class Contractors
    {
        [Key]
        public int ContractorId { get; set; }

        public string ContractorName { get; set; }

        //public EntityType EntityType { get; set; }

        //public int EntityId { get; set; }
    }

    public enum EntityType
    {
        Carriers, 
        Advisors, 
        MGAs
    }
}
