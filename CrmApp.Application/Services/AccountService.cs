using CrmApp.Application.Interfaces;
using CrmApp.Domain.Entities;
using CrmApp.Domain.Interfaces;

namespace CrmApp.Application.Services;

public class AccountService(IAccountRepository repository) : IAccountService
{
    public async Task<IEnumerable<Account>> GetAllAccountsAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Account?> GetAccountByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<(bool Success, string? Error, Account? Account)> CreateAccountAsync(Account account)
    {
        if (await repository.EmailExistsAsync(account.Email))
        {
            return (false, "An account with this email already exists.", null);
        }

        var createdAccount = await repository.AddAsync(account);
        return (true, null, createdAccount);
    }

    public async Task<(bool Success, string? Error)> UpdateAccountAsync(Account account)
    {
        var existingAccount = await repository.GetByIdAsync(account.Id);
        if (existingAccount is null)
        {
            return (false, "Account not found.");
        }

        if (await repository.EmailExistsAsync(account.Email, account.Id))
        {
            return (false, "An account with this email already exists.");
        }

        account.DateCreated = existingAccount.DateCreated;
        await repository.UpdateAsync(account);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> DeleteAccountAsync(int id)
    {
        var account = await repository.GetByIdAsync(id);
        if (account is null)
        {
            return (false, "Account not found.");
        }

        await repository.DeleteAsync(id);
        return (true, null);
    }
}

