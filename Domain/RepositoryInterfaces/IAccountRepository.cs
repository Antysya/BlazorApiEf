using Domain.Entites;
namespace Domain.RepositoryInterfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetById(int id, CancellationToken cancellationToken);
        Task<Account?> FindById(int id, CancellationToken cancellationToken);
        Task Add(Account account, CancellationToken cancellationToken);
        Task<Account?> FindByEmail(string email, CancellationToken cancellationToken);
    }
}
