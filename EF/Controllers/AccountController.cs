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
            catch (InvalidOperationException)
            {
                return BadRequest("Account with provided email already exists");
            }
            
        }

    }
}
