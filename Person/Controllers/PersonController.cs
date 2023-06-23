using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Person.Business;
using Person.DTO;

namespace Person.Controllers
{
    [ApiController]
    [Route("api/")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _personBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _personBusiness.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(PersonDto personDto)
        {
            var result = await _personBusiness.Add(personDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, PersonDto personDto)
        {
            var result = await _personBusiness.Update(id, personDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personBusiness.Delete(id);
            return Ok(result);
        }
    }
}

