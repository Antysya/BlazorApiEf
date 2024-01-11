using Domain.Exceptions;
using Domain.RepositoryInterfaces;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.ComponentModel.DataAnnotations;

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
            [Required]string name, 
            [EmailAddress]string email, 
            [Required] string password, 
            CancellationToken cancellationToken)
        {
            try
            {
                var newAccount = await _accountService.Register(name, email, password, cancellationToken);
                return newAccount;
            }
            catch (EmailAlreadyExistsException)
            {
                return BadRequest("Учетная запись с указанным адресом электронной почты уже существует");
            }
            
        }

    }
}
