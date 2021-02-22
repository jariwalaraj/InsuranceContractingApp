using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL.Models
{
    [Table("MGAs")]
    public class MGAs
    {
        [Key]
        [Column]
        public int MGAId { get; set; }

        [Column]
        public int ContractorId { get; set; }

        [Column]
        public string BusinessName { get; set; }

        [Column]
        public string BusinessAddress { get; set; }

        [Column]
        public string PhoneNumber { get; set; }

    }
}
