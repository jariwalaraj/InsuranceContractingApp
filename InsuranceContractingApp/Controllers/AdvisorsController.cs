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
    public class AdvisorsController : Controller
    {
        private IAdvisorRepository gAdvisorRepository;
        public AdvisorsController(IAdvisorRepository iCDbRepository)
        {
            gAdvisorRepository = iCDbRepository;
        }

        [HttpGet("getalladvisors")]
        public IActionResult Get()
        {
            var response = gAdvisorRepository.GetAdvisors();

            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            Advisors response = null;
            if (id > 0)
                response = gAdvisorRepository.GetAdvisorsById(id);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Advisors advisors)
        {
            Advisors response = null;
            if (advisors != null)
                response = gAdvisorRepository.UpdateAdvisors(advisors);

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            return Ok();
        }
    }
}
