using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL.Models
{
    [Table("Advisors")]
    public class Advisors
    {
        [Key]
        public int AdvisorsId { get; set; }

        [Column]
        public int ContractorId { get; set; }

        [Column]
        public string FirstName { get; set; }

        [Column]
        public string LastName { get; set; }

        [Column]
        public string Address { get; set; }

        [Column]
        public string PhoneNumber { get; set; }

        [Column]
        public string HealthStatus { get; set; }
    }
}
