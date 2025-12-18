using CrmApp.Domain.Entities;

namespace CrmApp.Domain.Interfaces;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAllAsync();
    Task<Account?> GetByIdAsync(int id);
    Task<Account?> GetByEmailAsync(string email);
    Task<Account> AddAsync(Account account);
    Task UpdateAsync(Account account);
    Task DeleteAsync(int id);
    Task<bool> EmailExistsAsync(string email, int? excludeId = null);
}

