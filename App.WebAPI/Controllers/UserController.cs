using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Model.ViewModel;
using App.Service.Interface;
using App.WebAPI.Infrastructure.DevExtreme;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] UserModel userModel)
        {
            var user = await _userService.ListAsync(n => n.UserName == userModel.UserName && n.PasswordHash == userModel.Password);
            if (user.Any() && user.FirstOrDefault() != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }
        [HttpGet, Route("getAll")]
        public IActionResult GetAll(DataSourceLoadOptions loadOptions)
        {
            var data = DataSourceLoader.Load(_userService.GetAll(), loadOptions);
            return Ok(data);
        }
    }
}