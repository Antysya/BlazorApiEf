using Domain.RepositoryInterfaces;
using Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepo;
        public AccountService(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo ?? throw new ArgumentNullException(nameof(accountRepo));
        }

        public async Task<Account> Register(
            string name,
            string email,
            string password,
            CancellationToken cancellationToken)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            Account? existedAccount = await _accountRepo.FindByEmail(email, cancellationToken);
            if (existedAccount != null)
            {
                throw new InvalidOperationException ("Provided emailis already registered by another user");
            }

            var newAccount = new Account()
            {
                Name = name,
                Email = email,
                Password = password
            };

            await _accountRepo.Add(newAccount, cancellationToken);
            return newAccount;
        }
    }
}
