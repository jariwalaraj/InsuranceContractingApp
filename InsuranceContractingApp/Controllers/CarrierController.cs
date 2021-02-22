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
    public class CarrierController : Controller
    {
        private ICarrierRepository gCarrierRepository;
        public CarrierController(ICarrierRepository iCDbRepository)
        {
            gCarrierRepository = iCDbRepository;
        }

        [HttpGet("getallcarriers")]
        public IActionResult Get()
        {
            var response = gCarrierRepository.GetCarriers();

            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            Carriers response = null;
            if (id > 0)
                response = gCarrierRepository.GetCarrierById(id);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Carriers advisors)
        {
            Carriers response = null;
            if (advisors != null)
                response = gCarrierRepository.UpdateCarriers(advisors);

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            return Ok(); 
        }
    }
}
