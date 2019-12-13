using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using KeenSap.Portal.API.Helpers;
using KeenSap.Portal.Service.Services;
using Microsoft.Extensions.Logging;
using KeenSap.Portal.Service.Dto.Request;

namespace KeenSap.Portal.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : GenericController
    {
        private readonly ILogger _logger;
        private readonly JWTSettings _options;
        private readonly IUserService _service;

        public AccountController(IUserService service, IOptions<JWTSettings> optionsAccessor, ILogger<AccountController> logger)
        { 
            _logger = logger;
            _service = service;
            _options = optionsAccessor.Value;
        }


        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] CredentialDto Credentials)
        {
            if (!ModelState.IsValid)
            {
                return ValidationFailed();
            }
            var user = await _service.AuthenticateAsync(Credentials.username, Credentials.password);
            if (user == null)
            {
                return Error("Incorrect username or password"); 
            }                

            return Success(user, "Sign In successfully");            
        }
    }
}
