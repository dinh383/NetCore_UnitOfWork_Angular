using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Entities;
using App.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using App.WebAPI.Infrastructure.DevExtreme;

namespace App.WebAPI.Controllers
{
    [Route("api/registerConsultative")]
    public class RegisterConsultativeController : Controller
    {
        private readonly IRegisterConsultativeService _registerConsultativeService;
        public RegisterConsultativeController(IRegisterConsultativeService registerConsultativeService)
        {
            this._registerConsultativeService = registerConsultativeService;
        }
        [HttpGet, Route("getAll")]
        public IActionResult GetAll(DataSourceLoadOptions loadOptions)
        {
            var data = DataSourceLoader.Load(_registerConsultativeService.GetAll(), loadOptions);
            return Ok(data);
        }
        [HttpPost, Route("addAsync")]
        public async Task<IActionResult> AddAsync([FromBody] RegisterConsultative registerConsultative)
        {
            var model = await _registerConsultativeService.AddAsync(registerConsultative);
            return Ok(model);
        }
        [HttpPut, Route("updateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody]RegisterConsultative registerConsultative)
        {
            var model = await _registerConsultativeService.UpdateAsync(registerConsultative);
            return Ok(model);
        }
        [HttpDelete, Route("deleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody]RegisterConsultative registerConsultative)
        {
            var model = await _registerConsultativeService.DeleteAsync(registerConsultative);
            return Ok(model);
        }
        [HttpGet, Route("getByIdAsync")]
        public async Task<IActionResult> GetSingleByIdAsync([FromQuery]int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var model = await _registerConsultativeService.GetSingleByIdAsync(id);
            if (model == null)
            {
                return NotFound(model);
            }
            return Ok(model);
        }
    }
}
