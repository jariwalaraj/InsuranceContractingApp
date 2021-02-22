using InsuranceContractingAPI.DAL;
using InsuranceContractingAPI.DAL.Models;
using InsuranceContractingAPI.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.Controllers
{
    [Route("api/[controller]")]
    public class MGAsController : Controller
    {
        private IMGAsRepository gIMGAsRepository;
        private IContractorsRepository gContractorsRepository;
        public MGAsController(IMGAsRepository iMGAsRepository, IContractorsRepository contractorsRepository)
        {
            gIMGAsRepository = iMGAsRepository;
            gContractorsRepository = contractorsRepository;
        }

        [HttpGet("getallmgas")]
        public IActionResult GetAllMGAs()
        {
            var response = gIMGAsRepository.GetMGAs();

            return Ok(response);
        }


        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            MGAs response = null;
            if (id > 0)
                response = gIMGAsRepository.GetMGAsById(id);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MGAs mGAs)
        {
            MGAs response = null;
            if (mGAs != null)
                response = gIMGAsRepository.UpdateMGAs(mGAs);

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] MGAs newMGA)
        {
            newMGA = gIMGAsRepository.InsertMGAs(newMGA);

            if(newMGA.MGAId != 0)
            {
                Contractors newContractor = new Contractors()
                {
                    ContractorName = string.Concat("MGA-", newMGA.MGAId)
                }; 

                gContractorsRepository.AddContractor(newContractor);

                newMGA.ContractorId = newContractor.ContractorId;
                gIMGAsRepository.UpdateMGAs(newMGA);
            }

            return Ok(Response);
        }
    }
}
