using CrmApp.Domain.Entities;

namespace CrmApp.Application.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<Account>> GetAllAccountsAsync();
    Task<Account?> GetAccountByIdAsync(int id);
    Task<(bool Success, string? Error, Account? Account)> CreateAccountAsync(Account account);
    Task<(bool Success, string? Error)> UpdateAccountAsync(Account account);
    Task<(bool Success, string? Error)> DeleteAccountAsync(int id);
}

