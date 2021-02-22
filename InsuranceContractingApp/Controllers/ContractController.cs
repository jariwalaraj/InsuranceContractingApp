using InsuranceContractingAPI.DAL;
using InsuranceContractingAPI.DAL.Models;
using InsuranceContractingAPI.DAL.Repositories;
using InsuranceContractingApp.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContractController : Controller
    {
        private IContractRepository gContractRepository;
        private IContractorsRepository gContractorRepository;
        public ContractController(IContractRepository iContractRepository, IContractorsRepository contractorsRepository)
        {
            gContractRepository = iContractRepository;
            gContractorRepository = contractorsRepository; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = gContractRepository.GetAllContracts();
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post([FromQuery] int id1, int id2)
        {
            bool response = false;

            //Should not be able to contract with self
            if (id1 == id2)
                return BadRequest();

            //Should not be able to have duplicate contracts
            if (!gContractRepository.DoesDirectContractExistAlready(id1, id2))
            {
                //Should be able to establish contract between any 2 entities
                response = gContractRepository.EstablishContract(id1, id2);
            }
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Terminate([FromQuery] int id)
        { 
            var response = gContractRepository.TerminateContract(id);

            return Ok(response);
        }

        [HttpGet("areconnected")]
        public IActionResult AreConnected([FromQuery] int id1, int id2)
        {
            //Get All the contracts
            var allContractors = gContractorRepository.GetAllContractors();

            //Initialize the QU algo with that length
            QuickUnionWeighted Quw = new QuickUnionWeighted(allContractors.Count);

            //Get all non terminated projects
            var allNonTerminatedContracts = gContractRepository.GetAllContracts();

            //Perform Union based on array ids
            //Assuming here the the ids in the contract are in series 
            foreach (Contracts contract in allNonTerminatedContracts)
            {
                Quw.Union(contract.ContractorIdA - 1, contract.ContractorIdB - 1);
            }

            if (id1 > allContractors.Count || id2 > allContractors.Count)
                return BadRequest(false);

            //Run the Is Connected command
            var response = Quw.IsConnected(id1 - 1, id2 - 1);

            return Ok(response);
        }
    }
}
