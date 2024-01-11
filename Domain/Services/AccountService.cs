using Domain.Exceptions;
using Domain.RepositoryInterfaces;
using Domain.Entites;
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
                throw new EmailAlreadyExistsException($"Предоставленный email {email}, уже зарегистрированные другим пользователем"); ; ; ;
            }
           
            var newAccount = new Account(name, email, password)
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
