using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL.Models
{
    public class Contracts
    {
        [Key]
        public int ContractId { get; set; }
        public int ContractorIdA { get; set; }
        public int ContractorIdB { get; set; }
        public DateTime? CreationDate { get; set; }
        
        [JsonIgnore]
        public bool IsTerminated { get; set; }

        [JsonIgnore]
        public DateTime? TerminationDate { get; set; }

    }
}
