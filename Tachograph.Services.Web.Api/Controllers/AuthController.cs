using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tachograph.Services.Infrastructure.Interface;
using Tachograph.Services.Infrastructure.Models;
using TachographServicesServices.Implementation;

namespace Tachograph.Services.Web.Api.Controllers
{
    [Route("api/UserManagement/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersRepo _userService;
        public AuthController(
            IUsersRepo userService) : base()
        {
            _userService = userService;
        }

        [Route("LoginUser")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginRequestModel loginRequestModel)
        {
            try
            {
                var result = await _userService.LoginAsync(loginRequestModel);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
