using Domain.Exceptions;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Entites;
using System.ComponentModel.DataAnnotations;
using HttpModels;

namespace ServerDb.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService) 
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        [HttpPost ("register")]
        public async Task<ActionResult<Account>> Register(
            RegistrationRequest request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var newAccount = await _accountService.Register(request.Name, request.Email, request.Password, cancellationToken);
                return newAccount;
            }
            catch (EmailAlreadyExistsException)
            {
                return BadRequest("Учетная запись с указанным адресом электронной почты уже существует");
            }
            
        }

    }
}
